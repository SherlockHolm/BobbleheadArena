using UnityEngine;
using System.Collections;

public class KeyBoardControllScheem : MonoBehaviour {

	public bool Left(int Player){
		if(Player == 5)
			return Input.GetKey(KeyCode.A);
		else if(Player == 6)
			return Input.GetKey(KeyCode.LeftArrow);
		else
			return false;
	}

	public bool Right(int Player){
		if(Player == 5)
			return Input.GetKey(KeyCode.D);
		else if(Player == 6)
			return Input.GetKey(KeyCode.RightArrow);
		else
			return false;
	}

	public bool Up(int Player){
		if(Player == 5)
			return Input.GetKey(KeyCode.W);
		else if(Player == 6)
			return Input.GetKey(KeyCode.UpArrow);
		else
			return false;
	}

	public bool Down(int Player){
		if(Player == 5)
			return Input.GetKey(KeyCode.S);
		else if(Player == 6)
			return Input.GetKey(KeyCode.DownArrow);
		else
			return false;
	}

	public float YAxis(int player){
		if(Up (player))
			return 1f;
		else if(Down(player))
			return -1f;
		else
			return 0;
	}

	public float xAxis(int player){
		if(Right(player))
			return 1f;
		else if(Left (player))
			return -1f;
		else 
			return 0;
	}

	public bool Shoot1(int Player){
		if(Player == 5)
			return Input.GetKeyDown(KeyCode.C);
		else if(Player == 6)
			return Input.GetKeyDown(KeyCode.K);
		else
			return false;
	}

	public bool Shoot2(int Player){
		if(Player == 5)
			return Input.GetKeyDown(KeyCode.V);
		else if(Player == 6)
			return Input.GetKeyDown(KeyCode.L);
		else
			return false;
	}

	public bool Boost(int Player){
		if(Player == 5)
			return Input.GetKeyDown(KeyCode.B);
		else if (Player == 6)
			return Input.GetKeyDown(KeyCode.J);
		else
			return false;
	}

	public bool StartKey(int Player){
		if(Player == 5)
			return Input.GetKeyDown(KeyCode.Return);
		else if(Player == 6)
			return Input.GetKeyDown(KeyCode.Return);
		else
			return false;
	}

}
