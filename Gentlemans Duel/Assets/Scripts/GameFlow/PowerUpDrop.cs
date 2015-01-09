using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpDrop : MonoBehaviour {

	public GameObject DropCrate;
	public GameObject[] PowerUps;
	public DropFequence dropFequence;
	private List<GameObject> ObjectsInSceen = new List<GameObject>();

	public void StartDrops(){
		Invoke("DropNewSuply", Random.Range(dropFequence.MinTime, dropFequence.MaxTime));
		DestroyAllForNewround();
	}

	void DropNewSuply(){
		if(PowerUps.Length != 0 && !GameState.instance.Pause){
			bool test = false;
			Vector3 dropSpot = Vector3.zero;
//
			while(!test){
				dropSpot = FindDropSpot();

				Ray ray = new Ray(dropSpot, Vector3.down);
			Debug.DrawRay(dropSpot,Vector3.down);
				RaycastHit hit;
				
				if (Physics.Raycast(ray, out hit, 100f)){
						if(hit.collider.tag == "GamePlatform"){
							test = true;
						}
					}
			}
				
			GameObject drop = Instantiate(DropCrate, dropSpot, Quaternion.identity) as GameObject;
			drop.GetComponent<DropCrate>().Contains = PowerUps[Random.Range(0, PowerUps.Length)];
			drop.GetComponent<DropCrate>().spawner = this;
			ObjectsInSceen.Add(drop);

			Invoke("DropNewSuply", Random.Range(dropFequence.MinTime, dropFequence.MaxTime));
		}
	}

	Vector3 FindDropSpot(){
		float X = dropFequence.Width / 2f;
		float Z = dropFequence.Height / 2f;
		Vector3 dropSpot = new Vector3(Random.Range(X,-X), transform.position.y, Random.Range(Z,-Z));

		return dropSpot;
	}

	public void AddToDestroyList(GameObject Other){
		ObjectsInSceen.Add (Other);
	}

	private void DestroyAllForNewround(){
		foreach(GameObject obj in ObjectsInSceen)
			Destroy(obj);
	}
}

[System.Serializable]
public class DropFequence{
	public float MinTime;
	public float MaxTime;

	public float Width;
	public float Height;
}
