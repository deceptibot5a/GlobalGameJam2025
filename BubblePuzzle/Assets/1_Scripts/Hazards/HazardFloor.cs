using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HazardFloor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moriste");

            StartCoroutine(ResetLevel());
        }
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(1);
    }
}
