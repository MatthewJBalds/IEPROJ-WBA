using UnityEngine;

public class ResourceGathering : MonoBehaviour
{
    public int resourceCount = 0;

    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Resource"))
        //{
        //    resourceCount++;
        //    Destroy(other.gameObject);
        //}
    }
}

//[TODO] Create resource objects in the scene and tag them as "Resource"