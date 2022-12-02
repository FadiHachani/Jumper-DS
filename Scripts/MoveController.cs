using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Action Move;

    public static Vector2 delta;

    public void OnBeginDrag(PointerEventData eventData)
    {
        delta = eventData.position;
        Move();
    }

    public void OnDrag(PointerEventData eventData)
    {
        delta = eventData.position;
        Move();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        delta = eventData.position;
    }
}
