using UnityEngine;

public class OrbRangeChecker : MonoBehaviour
{
    public Collider shooterRange;

    private void OnTriggerExit(Collider other)
    {
        if (other == shooterRange)
        {
            Destroy(gameObject);
        }
    }
}
