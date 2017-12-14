using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class class_orb : MonoBehaviour
{
	public Material mat_normal;
	public Material mat_glow;
	private Renderer rend;
	public int int_id;
	public AudioSource audioSource;

	public GameObject GO_gameLogic;

	void Start()
	{
		/// Get the renderer of the ball
		rend = GetComponent<Renderer>();
		int_id = -1;
	}

	public void fn_initOrb()
	{
		rend.material = mat_normal;
	}

	public void fn_click()
	{
		audioSource.Play();
		GO_gameLogic.GetComponent<class_gameLogic>().fn_clickedOrb(this.transform.position, int_id);
	}

	public void fn_pointerEnter()
	{
		rend.material = mat_glow;
	}

	public void fn_pointerExit()
	{
		rend.material = mat_normal;
	}
}
