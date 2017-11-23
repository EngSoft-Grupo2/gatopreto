using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
	public class ResultsModal : MonoBehaviour
	{

		public float openCloseTime = 0.5f;
		public AudioClip audioClip;
		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		private CanvasGroup canvasGroup;
		private Text modalText;
		private Button restartButton;
		private Button continueButton;
		

		void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
			modalText = ReferencesManager.instance.modalText.GetComponent<Text>();
			restartButton = ReferencesManager.instance.modalRestartButton.GetComponent<Button>();
			continueButton = ReferencesManager.instance.modalContinueButton.GetComponent<Button>();
		}

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			CloseModal(true);
		}

		public void OpenModal(string text, bool enableRestartButton, bool enableContinueButton, bool instant = false)
		{
			modalText.text = text;
			canvasGroup.blocksRaycasts = true;
			canvasGroup.interactable = true;
			restartButton.interactable = enableRestartButton;
			continueButton.interactable = enableContinueButton;
			if (instant)
			{
				canvasGroup.alpha = 1;
				return;
			}
			StartCoroutine(ModalFadeIn());
		}

        private IEnumerator ModalFadeIn()
        {
            float startTime = Time.time;
			float initValue = 0.0f, finalValue = 1.0f;
            while (Time.time < startTime + openCloseTime)
            {
                canvasGroup.alpha = Mathf.Lerp(initValue, finalValue, (Time.time - startTime) / openCloseTime);
                yield return null;
            }
			AudioControl.PlayAudioFromSource(audioClip);
            canvasGroup.alpha = finalValue;
        }

        public void CloseModal(bool instant = true)
		{
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
			if (instant)
			{
				canvasGroup.alpha = 0;
				return;
			}
			else
			{
				StartCoroutine(ModalFadeOut());
			}
		}

        private IEnumerator ModalFadeOut()
        {
            float startTime = Time.time;
			float initValue = 1.0f, finalValue = 0.0f;
            while (Time.time < startTime + openCloseTime)
            {
                canvasGroup.alpha = Mathf.Lerp(initValue, finalValue, (Time.time - startTime) / openCloseTime);
                yield return null;
            }
            canvasGroup.alpha = finalValue;
        }
    }
}