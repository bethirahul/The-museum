using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework.Internal.Commands;
using UnityEngine.Video;

public class class_gameLogic : MonoBehaviour
{
	public GameObject[] arr_GO_orb;

	public GameObject GO_player;
	public float float_playerHeight;
	public int int_playerPos;
	public int int_playerLastPos;

	public GameObject GO_welcomeScreen;
	public GameObject GO_infoScreen1;
	public GameObject GO_exitScreen;

	public GameObject[] arr_GO_screen;

	
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
	}

	//   B U T T O N S       
	public void fn_startButton()
	{
		GO_welcomeScreen.SetActive(false);
		GO_infoScreen1.SetActive(true);

		for(int i = 0; i < arr_GO_orb.Length; i++)
			arr_GO_orb[i].GetComponent<class_orb>().int_id = i;
	}

	public void fn_letsGoButton()
	{
		GO_infoScreen1.SetActive(false);
		GO_exitScreen.SetActive(false);
		int_playerPos = 0;
		fn_movePlayer(arr_GO_orb[1].transform.position, 1);
	}

	public void fn_exitButton()
	{
		Debug.Log("Will not exit in Editor mode");
		Application.Quit();
	}

	public void fn_clickedOrb(Vector3 p_point, int p_int_id) //  1 
	{
		fn_disableAllOrbs();
		fn_pauseAllVideos();
		if(p_int_id == 8)
		{
			GO_welcomeScreen.SetActive(false);
			GO_exitScreen.SetActive(false);
		}
		fn_movePlayer(p_point, p_int_id);
	}

	private void fn_pauseAllVideos() //  2 
	{
		for(int i = 0; i < arr_GO_screen.Length; i++)
			arr_GO_screen[i].GetComponent<VideoPlayer>().Pause();
	}

	private void fn_movePlayer(Vector3 p_point, int p_int_id) //  3 
	{
		int_playerLastPos = int_playerPos;
		int_playerPos     = p_int_id;
		Debug.Log("Moving to " + int_playerPos);

		fn_iTweenPlayerToPoint(p_point);
	}

	//   P L A Y E R   M O V E M E N T   //
	/// iTween movement to a point
	private void fn_iTweenPlayerToPoint(Vector3 p_point) //  4 
	{
		p_point.y = float_playerHeight;
		
		iTween.MoveTo
		(
			GO_player,
			iTween.Hash
			(
				"position", p_point,
				"speed", 5,
				"easetype", "linear",
				"oncomplete", "fn_checkMovement"
			)
		);
	}

	public void fn_checkMovement() //  5 
	{
		if(int_playerPos == 2 || int_playerPos == 7)
		{
			
			if(int_playerLastPos == int_playerPos - 1)
			{
				Debug.Log("Reached " + int_playerPos + ", Moving to " + (int_playerPos + 1));
				fn_movePlayer(arr_GO_orb[int_playerPos + 1].transform.position, int_playerPos + 1);
			}
			else
				fn_movePlayer(arr_GO_orb[int_playerPos - 1].transform.position, int_playerPos - 1);
		}
		else if(int_playerPos == 8)
		{
			if(int_playerLastPos == 7)
				fn_movePlayer(arr_GO_orb[0].transform.position, 0);
			else
				fn_movePlayer(arr_GO_orb[7].transform.position, 7);
		}
		else
			fn_enableDisableOrbs();
	}

	private void fn_enableDisableOrbs()
	{
		int l_int_nextOrbID, l_int_prevOrbID;

		l_int_nextOrbID = int_playerPos + 1;
		if(l_int_nextOrbID >= arr_GO_orb.Length)
			l_int_nextOrbID = 0;

		l_int_prevOrbID = int_playerPos - 1;
		if(l_int_prevOrbID < 0)
			l_int_prevOrbID = arr_GO_orb.Length - 1;

		fn_disableAllOrbs();

		if(l_int_nextOrbID != 1)
		{
			arr_GO_orb[l_int_nextOrbID].SetActive(true);
			///arr_GO_orb[l_int_nextOrbID].GetComponent<class_orb>().fn_initOrb();
		}
		arr_GO_orb[l_int_prevOrbID].SetActive(true);
		///arr_GO_orb[l_int_prevOrbID].GetComponent<class_orb>().fn_initOrb();

		if(l_int_nextOrbID == 1)
		{
			GO_welcomeScreen.SetActive(true);
			GO_exitScreen.SetActive(true);
		}
		fn_playVideo();
	}

	private void fn_disableAllOrbs()
	{
		for(int i = 0; i < arr_GO_orb.Length; i++)
			arr_GO_orb[i].SetActive(false);
	}

	private void fn_playVideo()
	{
		if(int_playerPos == 1)
		{
			arr_GO_screen[0].GetComponent<VideoPlayer>().Play();
			Debug.Log("Video playing on Screen: 0");
		}
		else if(int_playerPos >= 3 && int_playerPos <= 6)
		{
			arr_GO_screen[int_playerPos - 2].GetComponent<VideoPlayer>().Play();
			Debug.Log("Video playing on Screen: " + (int_playerPos - 2));
		}
	}
	
	//   U P D A T E                                                                                                    
	void Update()
	{
		/// To quit the application when X button is pressed
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			fn_exitButton();
    	}
	}
}
