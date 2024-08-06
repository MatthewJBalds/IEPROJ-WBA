using UnityEngine;

public class SideChecker : MonoBehaviour
{
    public enum Side { A, B }

    public Side side;

    public bool IsValidSide()
    {
        // Modify this method if you have additional logic to determine if the side is valid
        return side == Side.A || side == Side.B;
    }

    // For easier side assignment in the inspector
    public void SetSide(Side newSide)
    {
        side = newSide;
    }
}
