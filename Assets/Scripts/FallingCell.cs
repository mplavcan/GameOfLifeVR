// 

using UnityEngine;

public class FallingCell : MonoBehaviour
{
    [SerializeField] private Color color;

    private const int VanishingThreshold = -50;
    private GameObject cube;

    void Start()
    {
        FadeColorWithDepth();
    }

    void Update()
    {
        FadeColorWithDepth();
        RemoveFallenCell();
    }

    private void FadeColorWithDepth()
    {
        GetComponent<MeshRenderer>().material.color =
            color * (1 - (transform.position.y / VanishingThreshold));
    }

    private void RemoveFallenCell()
    {
        if (transform.position.y < VanishingThreshold)
            Destroy(gameObject);
    }
}
