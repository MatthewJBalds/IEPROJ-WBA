using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CardHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Card card;
    protected Vector2 dragStartPos;
    protected Vector2 dragEndPos;
    protected Camera mainCamera;

    protected virtual void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {}

    public void OnEndDrag(PointerEventData eventData)
    {
        dragEndPos = eventData.position;
        HandleCardAction();
    }

    protected abstract void HandleCardAction();
}
