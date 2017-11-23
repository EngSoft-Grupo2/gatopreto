using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
	public class AudioControl
	{
		public static void PlayAudioFromSource(AudioClip clip, bool loop = false)
		{
			if (!GameManager.instance.settings.audio)
				return;
			AudioSource source = loop ? GameManager.instance.loopAudioSource : GameManager.instance.audioSource;
			source.clip = clip;
			source.Play();
		}
	}
}