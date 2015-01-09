using UnityEngine;
using System.Collections;

public class Pillar : MonoBehaviour {
    
    public float TimeBeforeDestory;
    void Awake()
    {
		Invoke("KillYourself", TimeBeforeDestory);
    }

	private void KillYourself(){
		Destroy(this.gameObject);
	}
}
