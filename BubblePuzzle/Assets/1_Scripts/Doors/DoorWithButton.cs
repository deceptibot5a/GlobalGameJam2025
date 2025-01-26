using UnityEngine;

public class DoorWithButton : MonoBehaviour
{
    public void OpenDoor()
    {
        Debug.Log("Puerta abierta");
        this.gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        Debug.Log("Puerta cerrada");
        this.gameObject.SetActive(true);
    }
}
