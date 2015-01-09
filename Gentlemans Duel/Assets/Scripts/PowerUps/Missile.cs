using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class Missile : MonoBehaviour {
	
	public GameObject ArmedMissile;
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			other.gameObject.GetComponent<TankInfo>().SetNewAlternateFire(ArmedMissile);
		}

	}
}
