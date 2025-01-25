using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] DoorWithButton door;
    void OnCollisionEnter(Collision other)
    {
        door.OpenDoor();
    }
    void OnCollisionExit(Collision other)
    {
        door.CloseDoor();
    }
}
