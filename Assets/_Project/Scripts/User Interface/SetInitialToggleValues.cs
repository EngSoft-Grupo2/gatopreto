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

		// Use this for initialization
		void Start()
		{
			vibrationToggle.isOn = GameManager.instance.settings.vibration;
			audioToggle.isOn = GameManager.instance.settings.audio;
		}
	}
}