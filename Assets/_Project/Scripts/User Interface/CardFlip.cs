using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
    public class CardFlip : MonoBehaviour
    {
        public float flipTime;
        public CardFace face
        {
            set
            {
                if (value != _face)
                {
                    _face = value;
                    switch (value)
                    {
                        case CardFace.FRONT:
                            cardFront.gameObject.SetActive(true);
                            cardBack.gameObject.SetActive(false);
                            break;
                        case CardFace.BACK:
                            cardFront.gameObject.SetActive(false);
                            cardBack.gameObject.SetActive(true);
                            break;
                        default:
                            break;
                    }
                }
            }
            get
            {
                return _face;
            }
        }
        private CardFace _face = CardFace.FRONT;
        private bool isFlipping = false;
        private float waitTime;
        private CardDrag cardDrag;
        private Image image;
        private Transform cardFront;
        private Transform cardBack;
        private CanvasGroup descPanelCanvasGroup;

        void Awake()
        {
            image = GetComponent<Image>();
            cardDrag = GetComponent<CardDrag>();
            cardFront = transform.Find("Card Front");
            cardBack = transform.Find("Card Back");
            descPanelCanvasGroup = ReferencesManager.instance.cardDescription.GetComponent<CanvasGroup>();
            _face = CardFace.FRONT;
        }
        public void Flip()
        {
            if (isFlipping || !cardDrag.canChange)
                return;
            if (face == CardFace.FRONT)
                StartCoroutine(AnimateDescriptionFade(descPanelCanvasGroup, 1.0f, 0.0f, flipTime));
            else
                StartCoroutine(AnimateDescriptionFade(descPanelCanvasGroup, 0.0f, 1.0f, flipTime));
            StartCoroutine(AnimateCardFlip(90.0f, true, flipTime));
        }
        IEnumerator AnimateDescriptionFade(CanvasGroup canvasGroup, float initValue, float finalValue, float overTime)
        {
            float startTime = Time.time;
            while (Time.time < startTime + overTime)
            {
                canvasGroup.alpha = Mathf.Lerp(initValue, finalValue, (Time.time - startTime) / overTime);
                yield return null;
            }
            canvasGroup.alpha = finalValue;
        }
        IEnumerator AnimateCardFlip(float flipAngle, bool animatePosition, float overTime)
        {
            isFlipping = true;
            float startTime = Time.time;
            Quaternion startRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            Quaternion endRotation = Quaternion.Euler(0.0f, flipAngle, 0.0f);
            overTime = overTime / 2;
            while (Time.time < startTime + overTime)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, (Time.time - startTime) / overTime);
                yield return null;
            }
            transform.rotation = endRotation;
            if (face == CardFace.FRONT)
                face = CardFace.BACK;
            else if (face == CardFace.BACK)
                face = CardFace.FRONT;
            startTime = Time.time;
            while (Time.time < startTime + overTime)
            {
                transform.rotation = Quaternion.Slerp(endRotation, startRotation, (Time.time - startTime) / overTime);
                yield return null;
            }
            transform.rotation = startRotation;
            isFlipping = false;
            yield return null;
        }
    }
}