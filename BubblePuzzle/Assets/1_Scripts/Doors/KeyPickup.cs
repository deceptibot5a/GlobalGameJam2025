using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] DoorWithKey door;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetKey();
            Debug.Log("Puerta desbloqueada");
        }
    }

    void GetKey()
    {
        Debug.Log("Llave tomada");
        door.isLocked = false;

        this.gameObject.SetActive(false);
    }
}
