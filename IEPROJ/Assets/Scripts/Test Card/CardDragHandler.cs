using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject fireballPrefab;
    public LayerMask groundLayer;
    public float spawnHeight = 10.0f;
    public Player player;

    private int manaPool;


    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        manaPool = player.manaPool;
    }

    private void Update()
    {
        manaPool = player.manaPool;
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

            string CardId = this.gameObject.GetComponent<DisplayCard>().displayName;

            

            if (this.gameObject.GetComponent<DisplayCard>().displayCost <= player.manaPool)
            {
                
                if (CardId == "Fireball")
                {
                    Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
                    EventManager.ReduceMana(this.gameObject.GetComponent<DisplayCard>().displayCost);

                    Debug.Log(manaPool);
                }

                
            }

            int id = this.gameObject.GetComponent<DisplayCard>().ID;
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
