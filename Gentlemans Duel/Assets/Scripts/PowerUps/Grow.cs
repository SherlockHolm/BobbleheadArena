using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour {

	bool OnTank = false;
	public float PowerUpTime = 5f;
	public float SizeIncrease = 1.5f;
	public float MassIncrese = 1.5f;

	// Use this for initialization
	void Start () {
		if(this.GetComponentInParent<TankInfo>() != null)
			OnTank = true;

		if(OnTank)
			InvokePower();
	}

	void InvokePower(){
		this.transform.parent.localScale *= SizeIncrease;
		this.transform.parent.rigidbody.mass *= MassIncrese;

		Invoke("EndPower", PowerUpTime);
	}

	void EndPower(){
		this.transform.parent.localScale /= SizeIncrease;
		this.transform.parent.rigidbody.mass /= MassIncrese;

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
