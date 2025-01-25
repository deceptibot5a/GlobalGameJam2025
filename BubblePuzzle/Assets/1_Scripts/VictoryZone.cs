using UnityEngine;
using System.Collections;

public class VictoryZone : MonoBehaviour
{
    
    [SerializeField] GameObject Fireworks;
    [SerializeField] GameObject Pouff;
    [SerializeField] AudioSource Victory;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Fireworks.SetActive(true);
            Pouff.SetActive(true);
            Victory.PlayOneShot(Victory.clip);
            StartCoroutine(WaitAndExecute());
        }
    }
    
    IEnumerator WaitAndExecute()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Execute your desired action
        ExecuteAction();
    }
    
    void ExecuteAction()
    {
        Debug.Log("You win, WARP");
        // Add your custom logic here
    }
}


