using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float DestroyTime = 5f;

	// Use this for initialization
	void Start () {
		Invoke("DestroySelf", DestroyTime);
	}
	
	// Update is called once per frame
	void DestroySelf () {
		Destroy(this.gameObject);
	}
}
