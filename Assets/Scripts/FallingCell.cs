// 

using UnityEngine;

namespace GameOfLife
{
    public class FallingCell : MonoBehaviour
    {
        [SerializeField] private Color color;

        private const int VanishingThreshold = -50;

        private void Start()
        {
            FadeColorWithDepth();
        }

        private void Update()
        {
            FadeColorWithDepth();
            RemoveFallenCell();
        }

        private void FadeColorWithDepth()
        {
            GetComponent<MeshRenderer>().material.color =
                color * (1 - transform.position.y / VanishingThreshold);
        }

        private void RemoveFallenCell()
        {
            if (transform.position.y < VanishingThreshold)
                Destroy(gameObject);
        }
    }
}
