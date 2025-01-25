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

    public void Vanish()
    {
        
    }

    public void Resize(float amount)
    {
        
    }

    public void Instance()
    {
        
    }

    public void GenerateHUDRendder()
    {

    }
}
