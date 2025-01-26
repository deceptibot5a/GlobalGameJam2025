using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using KinematicCharacterController.Examples;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class VictoryZone : MonoBehaviour
{
    
    [SerializeField] GameObject Fireworks;
    [SerializeField] GameObject Pouff;
    [SerializeField] AudioSource Victory;
    [SerializeField] private GameObject Player;

    
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


