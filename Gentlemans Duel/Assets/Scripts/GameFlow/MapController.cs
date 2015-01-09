using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using XboxCtrlrInput;

public class MapController : MonoBehaviour {

	public GameObject[] SpawnPoints = new GameObject[4];
	public Text ScreenText;

	public GameObject[] DestroyObjects;
	public GameObject DestroyObjectParticle;
	public float TimeTillDestry;

	//Privates
	private int CountdownNumber = 3;

	private bool RoundOver = false;
	private bool GamesOver = false;

	private KeyBoardControllScheem KeyBoard = new KeyBoardControllScheem();
	public void Start(){
		GameState.instance.InitiateGame();
	}

	public void Update(){
		if(GamesOver && (XCI.GetButtonDown(XboxButton.Start) || KeyBoard.StartKey(5) || KeyBoard.StartKey(6)))
			Application.LoadLevel("PlayerSelect");
		else if(RoundOver && XCI.GetButtonDown(XboxButton.A) && !GamesOver){
			RoundOver = false;
			GameState.instance.NewRound();
		}else if(RoundOver && !GamesOver && (KeyBoard.Shoot1(5) || KeyBoard.Shoot1(6))){
			RoundOver = false;
			GameState.instance.NewRound();
		}
	}

	public List<GameObject> SpawnPlayers(GameObject[] Tanks){
		List<GameObject> returner = new List<GameObject>();
		for (int i = 0; i < Tanks.Length; i++) {
			returner.Add (Instantiate(Tanks[i], SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation) as GameObject);
			returner[i].GetComponent<TankInfo>().ControllerID = GameState.instance.ActivePlayer[i];
			returner[i].GetComponent<TankInfo>().CanMove = false;
		}
		ScreenText.text = "Get Ready !!";
		CountdownNumber = 0;
		Invoke("Countdown", 1f);

		for (int i = 0; i < DestroyObjects.Length; i++) {
			DestroyObjects[i].SetActive(true);	
		}

		if(GameObject.FindObjectOfType<PowerUpDrop>())
			GameObject.FindObjectOfType<PowerUpDrop>().StartDrops();

		return returner;
	}

	private void Countdown()
	{
		if(CountdownNumber == 0){
			ScreenText.text = "GO!!";
			Invoke("Countdown", 1f);
		}
		else if(CountdownNumber <= -1){
			ScreenText.text = "";
			foreach(GameObject AP in GameState.instance.AlivePlayers){
				AP.GetComponent<TankInfo>().CanMove = true;
				Invoke("DestroyCenter", TimeTillDestry);
			}
		}
		else{
			ScreenText.text = "! " + CountdownNumber + " !"; 
			Invoke("Countdown", 1f);
		}

		CountdownNumber--;
	}

	private void DestroyCenter(){
		for (int i = 0; i < DestroyObjects.Length; i++) {
			Instantiate(DestroyObjectParticle, DestroyObjects[i].transform.position + new Vector3(0,1,0), DestroyObjects[i].transform.rotation);
			DestroyObjects[i].gameObject.SetActive(false);
		}
	}

	public void AnounceWinner(){
		GameState.instance.Pause = true;
		int WinningPlayer = GameState.instance.ActivePlayer.IndexOf(GameState.instance.AlivePlayers[0].GetComponent<TankInfo>().ControllerID);
		ScreenText.text = "The winner is Player " + (WinningPlayer + 1);
		GameState.instance.Points[WinningPlayer]++;
		if(GameState.instance.Points[WinningPlayer] == 5){
			ScreenText.text = "PLAYER 1 IS THE ULTIMATE WINNER!";
			GamesOver = true;
		}
		RoundOver = true;
	}
	public void CallDraw(){
		ScreenText.text = "ITS A DRAW";
		RoundOver = true;
	}
}
