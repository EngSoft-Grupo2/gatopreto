using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjetoGatoPreto
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        public AnimationCurve resetAnimation;
        private Vector3 resetPosition;
        private Vector3 dragPosition;
        private EasyTween tween;
				private bool dragged = false;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake ()
        {
            this.tween = this.GetComponent<EasyTween> ();
        }
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start ()
        {
            this.resetPosition = this.tween.rectTransform.anchoredPosition;
        }
        public void OnBeginDrag (PointerEventData eventData)
        {
            dragPosition = this.transform.position - (Vector3) eventData.position;
        }
        public void OnDrag (PointerEventData eventData)
        {
						this.dragged = false;
            if (!this.tween.IsObjectOpened ())
						{
                this.transform.position = dragPosition + (Vector3) eventData.position;
								this.dragged = true;
						}
				}
        public void OnEndDrag (PointerEventData eventData)
        {
						if (!this.dragged)
								return;
            if (!this.tween.IsObjectOpened ())
            {
                this.tween.SetAnimationPosition (this.tween.rectTransform.anchoredPosition, this.resetPosition, resetAnimation, resetAnimation);
            }
            else
            {
                this.tween.SetAnimationPosition (this.resetPosition, this.tween.rectTransform.anchoredPosition, resetAnimation, resetAnimation);
            }
            tween.OpenCloseObjectAnimation ();
        }
    }
}