using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class class_player : MonoBehaviour
{
	public GameObject GO_gameLogic;
	
	public void fn_checkMovement()
	{
		GO_gameLogic.GetComponent<class_gameLogic>().fn_checkMovement();
	}
}
