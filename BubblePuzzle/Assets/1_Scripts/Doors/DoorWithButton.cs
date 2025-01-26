using UnityEngine;

public class DoorWithButton : MonoBehaviour
{
    [SerializeField] int requiredButtons;
    public int activeButtons;
    public void OpenDoor()
    {   if(activeButtons == requiredButtons)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void CloseDoor()
    {
        if(activeButtons != requiredButtons)
        {
            this.gameObject.SetActive(true);
        }
        
    }
}
