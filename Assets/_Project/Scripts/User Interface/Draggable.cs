using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Vector3 startPosition;
	private Vector3 dragPosition;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		startPosition = transform.position;
	}

    public void OnBeginDrag (PointerEventData eventData)
    {
		dragPosition = this.transform.position - (Vector3) eventData.position;
    }
    public void OnDrag (PointerEventData eventData)
    {
		this.transform.position =  dragPosition + (Vector3) eventData.position;
    }
    public void OnEndDrag (PointerEventData eventData)
    {
		this.transform.position = startPosition;
    }
}