using UnityEngine;
using System.Collections;

public class CharacterThrowBubbles : MonoBehaviour
{

    [SerializeField] private GameObject BubbleCannon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BubbleCannon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BubbleCannon.SetActive(true);
            StartCoroutine(ResetBubble());
        }
        
    }
    
    IEnumerator ResetBubble()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(0.5f);
        BubbleCannon.SetActive(false);
    }
}
