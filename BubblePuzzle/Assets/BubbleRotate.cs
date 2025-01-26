using UnityEngine;

public class BubbleRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 100, 0);
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
