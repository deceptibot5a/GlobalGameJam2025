using UnityEngine;

public class Ammonition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
        StaticEventHandler.GiveAmmonition();
            gameObject.SetActive(false);
        }
    }
}
