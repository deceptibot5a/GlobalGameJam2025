using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    string thisTag;
    public void InteractedWith()
    {
        StaticEventHandler.savedInteractable = this.gameObject;
        print(this.gameObject);
        Vanish();
    }

    private void OnEnable()
    {
        StaticEventHandler.OnSelected += InteractedWith;
        thisTag = this.gameObject.tag.ToString();

    }
    private void OnDisable()
    {
        StaticEventHandler.OnSelected -= InteractedWith;

    }
    private GameObject[] FindAllObjectsWithTag()
    {
        return GameObject.FindGameObjectsWithTag(thisTag);
        
    }


    public void Vanish()
    {
        
        foreach (GameObject obj in FindAllObjectsWithTag())
        {
            //PartSis
            Destroy(obj);
        }
    }


    public void Resize(float amount)
    {
        foreach (GameObject obj in FindAllObjectsWithTag())
        {
            obj.transform.localScale = new Vector3(obj.transform.localScale.x + amount, obj.transform.localScale.y + amount, obj.transform.localScale.z + amount);
        }
    }

    public void Instance()
    {
       
    }

    public void GenerateHUDRender()
    {

    }
}
