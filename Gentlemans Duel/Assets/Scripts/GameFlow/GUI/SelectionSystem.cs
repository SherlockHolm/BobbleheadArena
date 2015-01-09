using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class SelectionSystem : MonoBehaviour {

	public GameObject[] PickingPlatforms;
	public GameObject[] Tanks;

	public enum PickingState {Inactive, Picking, Selected};
	private PickingState[] pickingState = new PickingState[7]{PickingState.Inactive, PickingState.Inactive, PickingState.Inactive, PickingState.Inactive, PickingState.Inactive, PickingState.Inactive, PickingState.Inactive};
	private GameObject[] SelectedTanks = new GameObject[7];
	private int[] PlayerSelectionID = new int[7] {0,0,0,0,0,0,0};

	private GameObject[] SpawnedTanks = new GameObject[7];

	private bool[] PanCD = new bool[7] {false,false,false,false,false,false,false};
	private float[] TimeforCD = new float[7];

	private int LockedInPlayers = 0;

	public GameObject StartGameText;
	private KeyBoardControllScheem KeyBoard;

	void Start(){
		KeyBoard = new KeyBoardControllScheem();
		if(StartGameText != null)
			StartGameText.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		Inputs();
	}

	void Inputs(){
		GeneralInputs();

		RemovePanCD();
		CheckGameStart();
	}
	void GeneralInputs(){
		for(int i = 1; i <= 6; i++) {
			//Keyboard
			if(i == 6 || i == 5){
				if(!PanCD[i]){
					if(KeyBoard.Shoot1(i) && pickingState[i] == PickingState.Inactive)
						AddPlayers(i);

					else if(KeyBoard.Right(i) && pickingState[i] == PickingState.Picking)
						PanTanks(i, true);
						
					else if(KeyBoard.Left(i) && pickingState[i] == PickingState.Picking)
						PanTanks(i,false);

					else if(KeyBoard.Shoot1(i) && pickingState[i] == PickingState.Picking)
						Select(i);

					else if(KeyBoard.Shoot2(i) && pickingState[i] == PickingState.Picking)
						RemovePlayer(i);

					else if(KeyBoard.Shoot2(i) && pickingState[i] == PickingState.Selected)
						UnSelect(i);

				}
			}
			//Controller
			else{
				if(XCI.GetButtonDown(XboxButton.A,i) && pickingState[i] == PickingState.Inactive)
					AddPlayers(i);

				else if(XCI.GetAxis(XboxAxis.LeftStickX,i) > 0.5f && !PanCD[i] && pickingState[i] == PickingState.Picking)
					PanTanks(i, true);

				else if(XCI.GetAxis(XboxAxis.LeftStickX,i) < -0.5f && !PanCD[i] && pickingState[i] == PickingState.Picking)
					PanTanks(i, false);

				else if(XCI.GetButtonDown(XboxButton.A, i) && pickingState[i] == PickingState.Picking)
					Select (i);

				else if(XCI.GetButtonDown(XboxButton.B, i) && pickingState[i] == PickingState.Picking)
					RemovePlayer(i);

				else if(XCI.GetButtonDown(XboxButton.B, i) && pickingState[i] == PickingState.Selected)
					UnSelect(i);
			}
		}
	}

	void AddPlayers(int player){
		GameState.instance.AddPlayer(player);
		SpawnNewTank(player);
		pickingState[player] = PickingState.Picking;
		PanCD[player] = true;
		TimeforCD[player] = Time.time +.5f;
	}

	void PanTanks(int player, bool positive){
		if(positive){
			PlayerSelectionID[player]++;
			if(PlayerSelectionID[player] > Tanks.Length - 1)
				PlayerSelectionID[player] = 0;
		}else{
			PlayerSelectionID[player]--;
			if(PlayerSelectionID[player] < 0)
				PlayerSelectionID[player] = Tanks.Length - 1;
		}
		SpawnNewTank(player);
		PanCD[player] = true;
		TimeforCD[player] = Time.time + .5f;
	}

	void RemovePlayer(int player){
		GameState.instance.RemovePlayer(player);
		Destroy(SpawnedTanks[player]);
		pickingState[player] = PickingState.Inactive;
		PanCD[player] = true;
		TimeforCD[player] = Time.time + .5f;
	}

	void Select(int player){
		SelectedTanks[player] = Tanks[PlayerSelectionID[player]];
		pickingState[player] = PickingState.Selected;

		//Licks in the choise
		int CurrentPlatform = GameState.instance.ActivePlayer.IndexOf(player);
		PickingPlatforms[CurrentPlatform].renderer.material.SetColor("_Color", Color.red);
		LockedInPlayers++;
	}

	void UnSelect(int player){
		SelectedTanks[player] = null;
		pickingState[player] = PickingState.Picking;

		//Unlock the choise
		int CurrentPlatform = GameState.instance.ActivePlayer.IndexOf(player);
		PickingPlatforms[CurrentPlatform].renderer.material.SetColor("_Color", Color.white);
		LockedInPlayers--;
		PanCD[player] = true;
		TimeforCD[player] = Time.time + .5f;
	}
	
	void RemovePanCD(){
		for(int i = 1; i <= 6; i++){
			if(TimeforCD[i] != null){
				if(TimeforCD[i] < Time.time)
					PanCD[i] = false;
			}
		}
	}
	
	void SpawnNewTank(int ID){
		int CurrentPlatform = GameState.instance.ActivePlayer.IndexOf(ID);
		Destroy(SpawnedTanks[ID]);
		SpawnedTanks[ID] = Instantiate(Tanks[PlayerSelectionID[ID]], PickingPlatforms[CurrentPlatform].transform.position + new Vector3(0,1,0), PickingPlatforms[CurrentPlatform].transform.rotation) as GameObject;
		SpawnedTanks[ID].transform.localScale *= .4f;
		SpawnedTanks[ID].GetComponent<TankInfo>().SetInactive();
	}

	void CheckGameStart(){
		if(LockedInPlayers > 1){
			if(LockedInPlayers == GameState.instance.ActivePlayer.Count){
				if(StartGameText != null && !StartGameText.activeSelf)
					StartGameText.SetActive(true);
				for(int i = 1; i <= 4; i++){
					if(XCI.GetButtonDown(XboxButton.Start))
						StartGame();
				}
				for(int i = 5; i <= 6; i++){
					if(KeyBoard.StartKey(i))
						StartGame();
				}
			}
			else{
				if(StartGameText != null && StartGameText.activeSelf)
					StartGameText.SetActive(false);
			}
		}
		else{
			if(StartGameText != null && StartGameText.activeSelf)
				StartGameText.SetActive(false);
		}
	}

	void StartGame(){
		GameState.instance.SelectedTanks = new GameObject[GameState.instance.ActivePlayer.Count];
		for (int i = 0; i < SpawnedTanks.Length; i++) {
			if(SpawnedTanks[i] != null){
				GameState.instance.SelectedTanks[GameState.instance.ActivePlayer.IndexOf(i)] = Tanks[PlayerSelectionID[i]];
			}
		}
		Application.LoadLevel("Arena_Platform");
	}
}
