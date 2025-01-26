using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] DoorWithButton door;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("This entered me -> "+ other.name);
        door.activeButtons++;
        door.OpenDoor();
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("This Exited me -> "+ other.name);
        door.activeButtons--;
        door.CloseDoor();
    }
}
