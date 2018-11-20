// 

using UnityEngine;

public class FallingCell : MonoBehaviour
{
    private const int VanishingThreshold = -50;

    void Update()
    {
        RemoveFallenCell();
    }

    private void RemoveFallenCell()
    {
        if (transform.position.y < VanishingThreshold)
            Destroy(gameObject);
    }
}
