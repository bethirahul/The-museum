using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class class_videoPlayer : MonoBehaviour
{
	public VideoPlayer videoPlayer;
	private enum PlayerStateEnum
	{
		playing, paused, stopped
	}
	private PlayerStateEnum enum_playerState;

	// Use this for initialization
	void Start()
	{
		enum_playerState = PlayerStateEnum.stopped;
		videoPlayer = GetComponent<VideoPlayer>();
	}

	public void play()
	{
		if(!videoPlayer.isPlaying)
			videoPlayer.Play();
	}

	public void pause()
	{
		if(videoPlayer.isPlaying)
			videoPlayer.Pause();
	}

	public void stop()
	{
		if(videoPlayer.isPlaying)
			videoPlayer.Stop();
	}
}
