using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class class_orb : MonoBehaviour
{
	public Material mat_normal;
	public Material mat_glow;
	private Renderer rend;

	public GameObject GO_gameLogic;

	void Start()
	{
		/// Get the renderer of the ball
		rend = GetComponent<Renderer>();
	}

	public void fn_initOrb()
	{
		rend.material = mat_normal;
	}

	public void fn_click()
	{
		/// call function from GO_gameLogic
	}
	
	//   U P D A T E                                                                                                    
	void Update()
	{
		/// if hovering, then change material
	}
}
