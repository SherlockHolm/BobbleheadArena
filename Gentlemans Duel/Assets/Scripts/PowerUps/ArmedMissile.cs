using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class ArmedMissile : MonoBehaviour {

	public int PlayerID;
	public float speed;
	public float ExplotionRadius;
	public float Power;
	public float Knockback;

	private KeyBoardControllScheem KeyBoard = new KeyBoardControllScheem();

	// Update is called once per frame
	void Update () {
		//Move Rocket
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

		//Secondary fire
		if(PlayerID == 1 || PlayerID == 2 || PlayerID == 3 || PlayerID == 4){
			if(XCI.GetButtonDown(XboxButton.B, PlayerID))
				Explode();
		}else{
			if(KeyBoard.Shoot2(PlayerID))
				Explode();
		}
	}

	void Explode(){
		Collider[] colliders = Physics.OverlapSphere(transform.position, ExplotionRadius);
		foreach(Collider hit in colliders){
			if(hit.tag == "Player" && hit.rigidbody)
				hit.rigidbody.AddExplosionForce(Power, transform.position, ExplotionRadius);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
			Explode();
	}
}
