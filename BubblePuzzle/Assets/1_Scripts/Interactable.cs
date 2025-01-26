using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour, IInteractable
{
    string thisTag;
    [SerializeField] ExplosionEffect boomFX;
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
            boomFX.ActivateExplosion();
            //obj.GetComponentInChildren<GameObject>().SetActive(true);

            StartCoroutine(Dissapear(obj));
        }
    }
    
    IEnumerator Dissapear(GameObject item)
    {
        yield return new WaitForSeconds(3.0f);

        Destroy(item);
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
