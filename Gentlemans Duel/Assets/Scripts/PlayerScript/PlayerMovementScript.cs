using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class PlayerMovementScript : MonoBehaviour {

	private TankInfo tankInfo; 
	private KeyBoardControllScheem KeyBoard;

	// Use this for initialization
	void Start () {
		tankInfo = this.GetComponent<TankInfo>();
		KeyBoard = new KeyBoardControllScheem();
		if(tankInfo == null)
			Debug.LogError("A tank is missing TankInfo.cs");
	}
	
	// Update is called once per frame
	void Update () {

		float axisX = 0;
		float axisY = 0;

		//If the controller ID is 0, it will respont to any controller, othervise it will only respond to the controllerID given.
		if(tankInfo.ControllerID == 0){
			axisX = XCI.GetAxis(XboxAxis.LeftStickX);
			axisY = XCI.GetAxis(XboxAxis.LeftStickY);
		}
		else if(tankInfo.ControllerID == 1 || tankInfo.ControllerID == 2 || tankInfo.ControllerID == 3 || tankInfo.ControllerID == 4) {
			axisX = XCI.GetAxis(XboxAxis.LeftStickX, tankInfo.ControllerID);
			axisY = XCI.GetAxis(XboxAxis.LeftStickY, tankInfo.ControllerID);
		}
		else if(tankInfo.ControllerID == 5 || tankInfo.ControllerID == 6){
			axisX = KeyBoard.xAxis(tankInfo.ControllerID);
			axisY = KeyBoard.YAxis(tankInfo.ControllerID);
		}

		if(tankInfo.CanMove && !GameState.instance.Pause){
			rigidbody.AddRelativeForce(Vector3.forward * axisY * Time.deltaTime * tankInfo.MoveSpeed);
			transform.Rotate(new Vector3(0, axisX, 0) * tankInfo.RotationSpeed * Time.deltaTime);
		}
	}
}
