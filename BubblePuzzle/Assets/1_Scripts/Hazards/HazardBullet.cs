using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HazardBullet : MonoBehaviour
{
    private bool isProtected;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moriste");
            isProtected = true;

            StartCoroutine(ResetLevel());
        }
        else if (isProtected == false)
        {
            Destroy(this.gameObject);
        }
        
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(1);

    }
}
