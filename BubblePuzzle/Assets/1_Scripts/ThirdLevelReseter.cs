using UnityEngine;
using System.Collections.Generic;

public class ResetItemsSystem : MonoBehaviour
{
    // Stores the original positions of the items
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

    // Tracks the number of attempts
    private int attempts = 0;

    // The correct trigger sequence
    public List<string> correctSequence;

    // Tracks the player's trigger sequence
    private List<string> playerSequence = new List<string>();

    // Reference to the items to be reset
    public List<GameObject> items;

    private void Start()
    {
        // Save the original positions of all items
        foreach (var item in items)
        {
            originalPositions[item] = item.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Add an attempt if the player enters a trigger with the "AddAttempt" tag
        if (this.CompareTag("AddAttempt") & other.CompareTag("Player"))
        {
            AddAttempt();
        }

        // Check if the player is entering a sequence trigger
        if (this.CompareTag("SequenceTrigger")& other.CompareTag("Player"))
        {
            string triggerID = other.gameObject.name; // Use the name as the ID
            ProcessTrigger(triggerID);
            //AddAttempt();
        }
    }

    private void AddAttempt()
    {
        attempts++;
        Debug.Log($"Attempts: {attempts}");

        // Check if the number of attempts is equal to 4
        if (attempts == 4)
        {
            ResetItems();
            playerSequence.Clear();
            attempts = 0; // Reset attempts after resetting items
        }
    }

    private void ProcessTrigger(string triggerID)
    {
        // Add the trigger to the player's sequence
        playerSequence.Add(triggerID);

        // Check if the player's sequence matches the correct sequence so far
        for (int i = 0; i < playerSequence.Count; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                Debug.Log("Incorrect sequence! Resetting.");
                ResetItems();
                playerSequence.Clear();
                return;
            }
        }

        // If the sequence is complete and correct, do not reset
        if (playerSequence.Count == correctSequence.Count)
        {
            Debug.Log("Correct sequence completed! No reset.");
            playerSequence.Clear();
        }
    }

    public void ResetItems()
    {
        // Reset all items to their original positions
        foreach (var item in items)
        {
            item.transform.position = originalPositions[item];
        }

        Debug.Log("Items reset to original positions.");
    }
}
