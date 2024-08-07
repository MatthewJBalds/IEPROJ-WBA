using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject fireballPrefab;
    public GameObject skeletonPrefab;
    public GameObject towerPrefab;
    public LayerMask groundLayer;
    public float spawnHeight = 10.0f;

    private int manaPool;


    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        EventManager.TrackMana += UpdateMana;
    }
    private void OnDisable()
    {
        EventManager.TrackMana -= UpdateMana;
    }
    private void UpdateMana(int mana)
    {
        this.manaPool = mana;
        Debug.Log("Mana Added: " + manaPool);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
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

            int id = this.gameObject.GetComponent<DisplayCard>().ID;

            Debug.Log("Mana: " + manaPool);
            Debug.Log("Cost: " + this.gameObject.GetComponent<DisplayCard>().displayCost);
            int cost = this.gameObject.GetComponent<DisplayCard>().displayCost;

            if (this.manaPool >= cost)
            {
                switch (id)
                {
                    case 0:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
                    case 1:
                        Instantiate(skeletonPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
                    case 2:
                        Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
                    case 3:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
                    case 4:
                        Instantiate(skeletonPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
                    case 5:
                        Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
            
                    case 6:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
                    case 7:
                        Instantiate(skeletonPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(cost);
                        break;
                }



            }


            DeckManager.deckSize += 1;
            EventManager.DrawCards();
            EventManager.MoveCardToBottom(id);
            Destroy(this.gameObject);

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