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

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			if (isDummy)
				return;
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
		}

		void UpdateCard()
		{
			if (isDummy)
				return;
			cardTexture.sprite = Data.cardTexture;
			cardDescriptionText.text = Data.cardDescription;
			leftDecisionDropZone.Decision = Data.leftDecision;
			rightDecisionDropZone.Decision = Data.rightDecision;
			helpText.text = Data.helpText;
		}

	}
}