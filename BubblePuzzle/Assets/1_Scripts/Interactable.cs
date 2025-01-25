using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public void InteractedWith()
    {
        StaticEventHandler.savedInteractable = this.gameObject;
        print(this.gameObject);
    }

    private void OnEnable()
    {
        StaticEventHandler.OnSelected += InteractedWith;

    }
    private void OnDisable()
    {
        StaticEventHandler.OnSelected -= InteractedWith;

    }
}
