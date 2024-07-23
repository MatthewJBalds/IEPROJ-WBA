using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject fireballPrefab;
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
        this.manaPool += mana;
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

            if (manaPool >= cost)
            {

                Debug.Log("The Id is " + id);
                switch (id)
                {
                    case 0:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
                        break;
                    case 1:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
                        break;
                    case 2:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
                        break;
                    case 3:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
                        break;
                    case 4:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
                        break;
                    case 5:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
                        break;
                    case 6:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
                        break;
                    case 7:
                        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                        EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);
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
