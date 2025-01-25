using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public bool isLocked = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLocked)
            {
                Debug.Log("No puedes pasar");
            }
            else
            {
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        Debug.Log("Puerta abierta");
        this.gameObject.SetActive(false);
    }
}
