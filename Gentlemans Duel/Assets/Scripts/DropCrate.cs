using UnityEngine;
using System.Collections;

public class DropCrate : MonoBehaviour {

	public GameObject Contains;
	public PowerUpDrop spawner;
	public float DropSpeed = 2f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.up * DropSpeed * Time.deltaTime);
	}

	void UnpackPowerUp(){
		GameObject go = Instantiate(Contains, transform.position, transform.rotation) as GameObject;
		spawner.AddToDestroyList(go);
		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "GamePlatform")
			UnpackPowerUp();
	}
}
