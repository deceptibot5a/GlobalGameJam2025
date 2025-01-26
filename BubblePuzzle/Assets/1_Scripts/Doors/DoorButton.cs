using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] DoorWithButton door;
    void OnTriggerEnter(Collider other)
    {
        door.activeButtons++;
        door.OpenDoor();
    }
    void OnTriggerExit(Collider other)
    {
        door.activeButtons--;
        door.CloseDoor();
    }
}
