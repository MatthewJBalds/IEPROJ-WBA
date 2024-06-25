using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject fireballPrefab;
    public LayerMask groundLayer;
    public float spawnHeight = 10.0f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 worldPosition;
        if (TryGetWorldPosition(eventData.position, out worldPosition))
        {
            Vector3 spawnPosition = worldPosition + Vector3.up * spawnHeight;
            Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private bool TryGetWorldPosition(Vector2 screenPosition, out Vector3 worldPosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            worldPosition = hit.point;
            return true;
        }

        worldPosition = Vector3.zero;
        return false;
    }
}
