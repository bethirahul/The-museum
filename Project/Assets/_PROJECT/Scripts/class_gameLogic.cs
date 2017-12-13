using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class class_gameLogic : MonoBehaviour
{
	public GameObject GO_entrance; 	/// 0
	public GameObject GO_first;		/// 1
	public GameObject GO_first_1;   /// 2
	public GameObject GO_second;    /// 3
	public GameObject GO_third;     /// 4
	public GameObject GO_fourth;    /// 5
	public GameObject GO_fifth;     /// 6
	public GameObject GO_fifth_1;   /// 7
	public GameObject GO_fifth_2;   /// 8

	private Vector3[] arr_point;

	public GameObject GO_player;

	public GameObject GO_welcomeScreen;
	public GameObject GO_infoScreen1;
	public GameObject GO_infoScreen2;
	
	//   S T A R T                                                                                                      
	void Start ()
	{
		arr_point    = new Vector3[9];
		arr_point[0] = GO_entrance.transform.position;
		arr_point[1] = GO_first.transform.position;
		arr_point[2] = GO_first_1.transform.position;
		arr_point[3] = GO_second.transform.position;
		arr_point[4] = GO_third.transform.position;
		arr_point[5] = GO_fourth.transform.position;
		arr_point[6] = GO_fifth.transform.position;
		arr_point[7] = GO_fifth_1.transform.position;
		arr_point[8] = GO_fifth_2.transform.position;

		fn_initGame();
	}

	//   I N I T           
	private void fn_initGame()
	{
		GO_player.transform.position = arr_point[0];
		GO_welcomeScreen.SetActive(true);
		GO_infoScreen1.SetActive(false);
		GO_infoScreen2.SetActive(false);
	}

	//   B U T T O N S       
	public void fn_startButton()
	{
		GO_welcomeScreen.SetActive(false);
		GO_infoScreen1.SetActive(true);
	}

	public void fn_letsGoButton()
	{
		GO_infoScreen1.SetActive(false);
		GO_infoScreen2.SetActive(true);
		/// iTween
	}
	
	//   U P D A T E                                                                                                    
	void Update ()
	{
		
	}
}
