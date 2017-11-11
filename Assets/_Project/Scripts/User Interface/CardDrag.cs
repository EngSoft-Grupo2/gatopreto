using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjetoGatoPreto
{
    public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool canChange
        {
            get
            {
                return (!dragged && !tween.IsObjectOpened());
            }
        }
        public AnimationCurve resetAnimation;
        private Vector3 resetPosition;
        private Vector3 dragPosition;
        private EasyTween tween;
        private bool dragged = false;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            tween = GetComponent<EasyTween>();
        }
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            resetPosition = tween.rectTransform.anchoredPosition;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            dragPosition = transform.position - (Vector3) eventData.position;
        }
        public void OnDrag(PointerEventData eventData)
        {
            dragged = false;
            if (!tween.IsObjectOpened())
            {
                transform.position = dragPosition + (Vector3) eventData.position;
                dragged = true;
            }
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!dragged)
                return;
            if (!tween.IsObjectOpened())
            {
                tween.SetAnimationPosition(tween.rectTransform.anchoredPosition, resetPosition, resetAnimation, resetAnimation);
            }
            else
            {
                tween.SetAnimationPosition(resetPosition, tween.rectTransform.anchoredPosition, resetAnimation, resetAnimation);
            }
            dragged = false;
            tween.OpenCloseObjectAnimation();
        }
    }
}