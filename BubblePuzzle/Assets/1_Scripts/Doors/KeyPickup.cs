using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] DoorWithKey door;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetKey();
        }
    }

    void GetKey()
    {
        door.isLocked = false;

        this.gameObject.SetActive(false);
    }
}
