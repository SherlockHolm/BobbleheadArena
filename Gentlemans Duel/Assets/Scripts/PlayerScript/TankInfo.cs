using UnityEngine;
using System.Collections;

/// <summary>
/// The Script where tanks find there info.
/// </summary>
public class TankInfo : MonoBehaviour {

	public int ControllerID;

	public bool CanMove = false;

	public float MoveSpeed = 65f;
	public float RotationSpeed = 75f;

	public GameObject Bullet;
	public Transform ShootPoint;
	public float BulletSpeed = 200f;

	public float ShootCooldown = 2f;
	public float ShootRecoil = 50f;

	public float BoostCooldown = 5f;
	public float BoostStrenght = 2.2f;

	public GameObject AlternateFire;


	public void SetInactive(){
		this.GetComponent<PlayerMovementScript>().enabled = false;
		this.GetComponent<PlayerAttackScript>().enabled = false;
	}

	public void SetActive(){
		this.GetComponent<PlayerMovementScript>().enabled = true;
		this.GetComponent<PlayerAttackScript>().enabled = true;
	}

	public void SetNewAlternateFire(GameObject New){
		AlternateFire = New;
	}

}


