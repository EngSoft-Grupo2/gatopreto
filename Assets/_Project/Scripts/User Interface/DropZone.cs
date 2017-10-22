using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    public class DropZone : MonoBehaviour
    {
        public CanvasGroup decisionDisplay;
        public float fadeTime = 0.25f;

        void OnTriggerEnter2D (Collider2D other)
        {
            StartCoroutine(this.AnimateCanvasGroupAlpha(decisionDisplay, 0.0f, 1.0f, fadeTime));
        }

        void OnTriggerExit2D(Collider2D other)
        {
            StartCoroutine(this.AnimateCanvasGroupAlpha(decisionDisplay, 1.0f, 0.0f, fadeTime));
        }

        IEnumerator AnimateCanvasGroupAlpha (CanvasGroup canvasGroup, float initValue, float finalValue, float overTime)
        {
            float startTime = Time.time;
            while (Time.time < startTime + overTime)
            {
                canvasGroup.alpha = Mathf.Lerp (initValue, finalValue, (Time.time - startTime) / overTime);
                yield return null;
            }
            canvasGroup.alpha = finalValue;
        }
    }
}