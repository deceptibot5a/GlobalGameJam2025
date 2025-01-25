using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Victory");
        }
    }
}
