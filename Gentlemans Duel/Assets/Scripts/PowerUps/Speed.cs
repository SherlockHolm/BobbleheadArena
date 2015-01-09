using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour {
	
	bool OnTank = false;
	public float PowerUpTime = 5f;
	public float MoveSpeedMultiplyer = 1.5f;
	public float RotationSpeedMultiplayer = 1.5f;
	
	// Use this for initialization
	void Start () {
		if(this.GetComponentInParent<TankInfo>() != null)
			OnTank = true;
		
		if(OnTank)
			InvokePower();
	}
	
	void InvokePower(){
		this.GetComponent<TankInfo>().MoveSpeed *= MoveSpeedMultiplyer;
		this.GetComponent<TankInfo>().RotationSpeed *= RotationSpeedMultiplayer;
		
		Invoke("EndPower", PowerUpTime);
	}
	
	void EndPower(){
		this.GetComponent<TankInfo>().MoveSpeed /= MoveSpeedMultiplyer;
		this.GetComponent<TankInfo>().RotationSpeed /= RotationSpeedMultiplayer;
		
		Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			this.transform.parent = other.transform;
			this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
			this.collider.enabled = false;
			
			Start ();
		}
	}
}
