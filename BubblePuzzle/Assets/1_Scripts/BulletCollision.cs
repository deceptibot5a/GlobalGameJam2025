using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.InteractedWith();   
        }

        Destroy(this.gameObject);
    }


    void Notify( )
    {
        print(StaticEventHandler.savedInteractable);
    }
}
