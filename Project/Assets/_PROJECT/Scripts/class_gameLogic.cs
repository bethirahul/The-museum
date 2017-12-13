using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework.Internal.Commands;

public class class_gameLogic : MonoBehaviour
{
	public GameObject[] arr_GO_orb;

	public GameObject GO_player;
	public float float_playerHeight;

	public GameObject GO_welcomeScreen;
	public GameObject GO_infoScreen1;
	public GameObject GO_infoScreen2;

	
	//   S T A R T                                                                                                      
	void Start()
	{
		fn_initGame();
	}

	//   I N I T           
	private void fn_initGame()
	{
		Vector3 l_vec3_pos = arr_GO_orb[0].transform.position;
		l_vec3_pos.y = float_playerHeight;
		GO_player.transform.position = l_vec3_pos;

		GO_welcomeScreen.SetActive(true);
		GO_infoScreen1.SetActive(false);
		GO_infoScreen2.SetActive(false);
	}

	//   B U T T O N S       
	public void fn_startButton()
	{
		GO_welcomeScreen.SetActive(false);
		GO_infoScreen1.SetActive(true);

		for(int i = 0; i < arr_GO_orb.Length; i++)
		{
			///arr_GO_orb[i].GetComponent<class_orb>().fn_initOrb();
			arr_GO_orb[i].GetComponent<class_orb>().int_id = i;
		}
	}

	public void fn_letsGoButton()
	{
		GO_infoScreen1.SetActive(false);
		GO_infoScreen2.SetActive(true);
		fn_movePlayerToPoint(arr_GO_orb[1].transform.position);
	}

	//   P L A Y E R   M O V E M E N T   //
	/// iTween movement to a point
	private void fn_movePlayerToPoint(Vector3 p_point)
	{
		p_point.y = float_playerHeight;
		
		iTween.MoveTo
		(
			GO_player,
			iTween.Hash
			(
				"position", p_point,
				"time", 2,
				"easetype", "linear"
			)
		);
	}
	
	//   U P D A T E                                                                                                    
	void Update()
	{
		/// To quit the application when X button is pressed
		if(Input.GetKeyDown(KeyCode.Escape))
		{
        	Application.Quit();
    	}

		if(Input.GetMouseButton(0))
		{
        	
    	}
	}
}
