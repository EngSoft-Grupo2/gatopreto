using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
    public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public float fadeTime = 0.25f;
        public CardDecision Decision
        {
            set
            {
                decision = value;
                decisionDescriptionText.text = decision.decisionDescription;
            }
            get { return decision; }
        }
        private CardDecision decision;
        private CanvasGroup decisionDisplay;
        private Text decisionDescriptionText;
        private bool isActive = false;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            decisionDisplay = transform.Find("Decision").GetComponent<CanvasGroup>();
            decisionDescriptionText = decisionDisplay.transform.Find("Text").GetComponent<Text>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            isActive = true;
            if (GameManager.instance.settings.vibration)
                Handheld.Vibrate();
            StartCoroutine(this.AnimateCanvasGroupAlpha(decisionDisplay, 0.0f, 1.0f, fadeTime));
        }

        void OnTriggerExit2D(Collider2D other)
        {
            isActive = false;
            StartCoroutine(this.AnimateCanvasGroupAlpha(decisionDisplay, 1.0f, 0.0f, fadeTime));
        }

        IEnumerator AnimateCanvasGroupAlpha(CanvasGroup canvasGroup, float initValue, float finalValue, float overTime)
        {
            float startTime = Time.time;
            while (Time.time < startTime + overTime)
            {
                canvasGroup.alpha = Mathf.Lerp(initValue, finalValue, (Time.time - startTime) / overTime);
                yield return null;
            }
            canvasGroup.alpha = finalValue;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (isActive == false)
                return;
            GameManager.instance.player.ApplyDecisionEffects(decision);
            eventData.pointerDrag.GetComponent<CardDrag>().PlayDecisionAnimation();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}