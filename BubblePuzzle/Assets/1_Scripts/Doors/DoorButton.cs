using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] DoorWithButton door;
    void OnTriggerEnter(Collider other)
    {
        door.OpenDoor();
    }
    void OnTriggerExit(Collider other)
    {
        door.CloseDoor();
    }
}
