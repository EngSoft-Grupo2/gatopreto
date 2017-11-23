using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
	public class AudioControl
	{
		public static void PlayAudioFromSource(AudioClip clip)
		{
			if (!GameManager.instance.settings.audio)
				return;
			AudioSource source = GameManager.instance.audioSource;
			source.clip = clip;
			source.Play();
		}
	}
}