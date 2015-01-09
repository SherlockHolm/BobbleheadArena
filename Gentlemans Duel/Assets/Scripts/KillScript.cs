using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log (other.tag);
		if(other.tag == "Player"){
			GameState.instance.KillPlayer(other.gameObject);
		}
	}
}
