using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class PlayerAttackScript : MonoBehaviour {

	private TankInfo tankInfo;
	private KeyBoardControllScheem KeyBoard;

	//Desides if cooldown of shot is still active 
	private bool Shoot = true;
	private bool Boost = true;

	void Awake(){
		KeyBoard = new KeyBoardControllScheem();
		tankInfo = this.GetComponent<TankInfo>();
	}

	// Update is called once per frame
	void Update () {
		if(tankInfo.ControllerID == 1 || tankInfo.ControllerID == 2 || tankInfo.ControllerID == 3 || tankInfo.ControllerID == 4){
			if (XCI.GetButtonDown(XboxButton.A, tankInfo.ControllerID) && Shoot && tankInfo.CanMove && !GameState.instance.Pause)
				ShootMain();

			else if (XCI.GetButtonDown(XboxButton.X, tankInfo.ControllerID) && Boost && tankInfo.CanMove && !GameState.instance.Pause)
				BoostTank ();

			else if (XCI.GetButtonDown(XboxButton.B, tankInfo.ControllerID) && tankInfo.CanMove && !GameState.instance.Pause)
				ShootAlternateFire();

		} else if(tankInfo.ControllerID == 5 || tankInfo.ControllerID == 6){
			if(KeyBoard.Shoot1(tankInfo.ControllerID) && Shoot && tankInfo.CanMove && !GameState.instance.Pause)
				ShootMain();

			else if(KeyBoard.Boost(tankInfo.ControllerID) && Boost && tankInfo.CanMove && !GameState.instance.Pause)
				BoostTank();

			else if(KeyBoard.Shoot2(tankInfo.ControllerID) && tankInfo.CanMove && !GameState.instance.Pause)
				ShootAlternateFire();
		}
	}

	private void ShootMain(){
		//Commentt untill effect is ready
		//			GameObject MusselEffect = Instantiate(ShootingFireP2, BulletSpawn2.transform.position, BulletSpawn2.transform.rotation) as GameObject;
		
		rigidbody.AddForce(-transform.forward * tankInfo.ShootRecoil, ForceMode.Impulse);
		GameObject Bullet = Instantiate(tankInfo.Bullet, tankInfo.ShootPoint.position, tankInfo.ShootPoint.rotation) as GameObject;
		if(Bullet.GetComponent<ProjectileScript>() != null)
			Bullet.GetComponent<ProjectileScript>().Owner = this.gameObject;
		Bullet.rigidbody.velocity = transform.TransformDirection(Vector3.forward * tankInfo.BulletSpeed);
		Shoot = false;
		
		Invoke("SetShootActive", tankInfo.ShootCooldown);
	}

	private void BoostTank(){
		rigidbody.AddForce(transform.forward * tankInfo.BoostStrenght, ForceMode.Impulse);
		Boost = false;
		Invoke("SetBoostActive", tankInfo.BoostCooldown);
	}

	private void ShootAlternateFire(){
		if(tankInfo.AlternateFire != null){
			GameObject go = Instantiate(tankInfo.AlternateFire, tankInfo.ShootPoint.position, tankInfo.ShootPoint.rotation) as GameObject;
			tankInfo.AlternateFire = null;
		}
	}


	private void SetShootActive(){
		Shoot = true;
	}

	private void SetBoostActive(){
		Boost = true;
	}
}
