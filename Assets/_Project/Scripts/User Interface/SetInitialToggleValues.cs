using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
	public class SetInitialToggleValues : MonoBehaviour
	{

		public Toggle vibrationToggle;
		public Toggle audioToggle;
		public AudioClip audioClip;

		// Use this for initialization
		void Start()
		{
			
			vibrationToggle.Set(GameManager.instance.settings.vibration, false);
			audioToggle.Set(GameManager.instance.settings.audio, false);
			if (GameManager.instance.firstTimeLoaded) {
				AudioControl.PlayAudioFromSource(audioClip, true);
				GameManager.instance.firstTimeLoaded = false;
			}
		}
	}
}