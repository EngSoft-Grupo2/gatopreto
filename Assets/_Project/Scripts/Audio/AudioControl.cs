using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl
{
	public static void PlayAudioFromSource(AudioClip clip, AudioSource source)
	{
		source.clip = clip;
		source.Play();
	}
}