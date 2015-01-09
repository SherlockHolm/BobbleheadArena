using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public float LiveTime = 1.2f;
	public AudioClip Audio;
	public GameObject Effect;
	public GameObject Owner;
	
	
	// Use this for initialization
	void Start () {
		if(Owner != null){
			if(Audio)
				Owner.audio.PlayOneShot(Audio);
			if(Effect){
				GameObject go = Instantiate(Effect, transform.position, Effect.transform.rotation) as GameObject;
				go.AddComponent<SelfDestroy>();
			}
		}
		Invoke("KillYourself", LiveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void KillYourself(){
		Destroy(this.gameObject);
	}
}

