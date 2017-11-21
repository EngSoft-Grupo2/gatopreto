using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
	public class Card : MonoBehaviour
	{
		public CardData defaultCard;
		public bool isDummy = false;
		public AudioClip onDecisionAudioClip;
		public CardData Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value ? value : defaultCard;
				UpdateCard();
			}
		}
		private CardData data;
		private Image cardTexture;
		private Text cardDescriptionText;
		private DropZone leftDecisionDropZone;
		private DropZone rightDecisionDropZone;
		private Text helpText;
		private AudioSource audioSource;
		private CanvasGroup canvasGroup;
		private CardDrag drag;
		private CardFlip flip;
        private Vector3 originalPosition;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
		{
			drag = GetComponent<CardDrag>();
			flip = GetComponent<CardFlip>();
			if (isDummy)
				return;
			audioSource = GetComponent<AudioSource>();
			canvasGroup = GetComponent<CanvasGroup>();
			cardTexture = ReferencesManager.instance.cardFront.GetComponent<Image>();
			cardDescriptionText = ReferencesManager.instance
				.cardDescriptionText
				.GetComponent<Text>();
			leftDecisionDropZone = ReferencesManager.instance
				.leftDropZone
				.GetComponent<DropZone>();
			rightDecisionDropZone = ReferencesManager.instance
				.rightDropZone
				.GetComponent<DropZone>();
			helpText = ReferencesManager.instance
				.helpText
				.GetComponent<Text>();
			originalPosition = transform.localPosition;
		}

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			Data = null;
			if (!isDummy)
			{
				EnableDrag();
				EnableFlip();
			}
		}

		void UpdateCard()
		{
			if (isDummy)
				return;
			transform.localPosition = originalPosition;
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			canvasGroup.alpha = 1.0f;
			cardTexture.sprite = Data.cardTexture;
			cardDescriptionText.text = Data.cardDescription;
			leftDecisionDropZone.Decision = Data.leftDecision;
			rightDecisionDropZone.Decision = Data.rightDecision;
			helpText.text = Data.helpText;
		}

		public void DoDecision(CardDecision decision)
		{
			StartCoroutine(DecisionAnimationSequence(decision));
		}

		private IEnumerator DecisionAnimationSequence(CardDecision decision)
		{
			GameManager.instance.player.ApplyDecisionEffects(decision);
			DisableDrag();
			DisableFlip();
			AudioControl.PlayAudioFromSource(onDecisionAudioClip, audioSource);
			float startTime = Time.time,
				overTime = 1.0f;
			Vector3 initScale = new Vector3(1.0f, 1.0f, 1.0f);
			Vector3 finalScale = new Vector3(2.0f, 2.0f, 2.0f);

			while (Time.time < startTime + overTime)
			{
				canvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, (Time.time - startTime) / overTime);
				transform.localScale = Vector3.Lerp(initScale, finalScale, (Time.time - startTime) / overTime);
				yield return null;
			}
			ReferencesManager.instance.deck.DrawNext();
			EnableDrag();
			EnableFlip();
		}

		public void EnableFlip()
		{
			flip.canFlip = true;
		}

		public void DisableFlip()
		{
			flip.canFlip = false;
		}

		public void EnableDrag()
		{
			drag.canDrag = true;
		}

		public void DisableDrag()
		{
			drag.canDrag = false;
		}
	}
}