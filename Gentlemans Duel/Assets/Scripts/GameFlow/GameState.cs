using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public static GameState instance;

	public bool Pause = false;
	public List<int> ActivePlayer = new List<int>();
	public int[] Points;
	public GameObject[] SelectedTanks;
	
	public List<GameObject> AlivePlayers;

	void Awake(){
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	public void AddPlayer(int ID){
		if(!ActivePlayer.Contains(ID))
			ActivePlayer.Add (ID);
	}

	public void RemovePlayer(int ID){
		if(ActivePlayer.Contains(ID))
			ActivePlayer.Remove(ID);

	}

	public void InitiateGame(){
		Points = new int[ActivePlayer.Count];
		NewRound();
	}

	public void KillPlayer(GameObject DeathPlayer){
		AlivePlayers.Remove(DeathPlayer);
		Destroy(DeathPlayer);
		if(AlivePlayers.Count == 1)
			GameObject.FindObjectOfType<MapController>().AnounceWinner();
		if(AlivePlayers.Count <= 0)
			GameObject.FindObjectOfType<MapController>().CallDraw();
	}

	public void NewRound(){
		for (int i = 0; i < AlivePlayers.Count; i++) {
			Destroy(AlivePlayers[i]);
		}
		Pause = false;
		AlivePlayers = GameObject.FindObjectOfType<MapController>().SpawnPlayers(SelectedTanks);
	}

}
