using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        StaticEventHandler.OnSelected += Notify;
        StaticEventHandler.NotifySelected(other.gameObject);
        StaticEventHandler.OnSelected -= Notify;
    }

    void Notify( )
    {
        print(StaticEventHandler.savedInteractable);
    }
}
