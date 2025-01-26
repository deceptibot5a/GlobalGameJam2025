using UnityEngine;
using System.Collections.Generic;

public class ResetItemsSystem : MonoBehaviour
{
    // Stores the original positions of the items
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

    // Tracks the number of attempts
    private int attempts = 0;

    // The correct trigger sequence (represented as integers)
    public List<int> correctSequence;

    // Tracks the player's trigger sequence
    private List<int> playerSequence = new List<int>();

    // Reference to the items to be reset
    public List<GameObject> items;

    // Reference to the tiles that count as AddAttempt
    public List<GameObject> addAttemptTiles;

    // Reference to the tiles that count as SequenceTrigger and their IDs
    public List<GameObject> sequenceTriggerTiles;
    public List<int> sequenceTriggerIDs;

    private void Start()
    {
        // Save the original positions of all items
        foreach (var item in items)
        {
            originalPositions[item] = item.transform.position;
        }

        // Ensure sequenceTriggerTiles and sequenceTriggerIDs are of the same size
        if (sequenceTriggerTiles.Count != sequenceTriggerIDs.Count)
        {
            Debug.LogError("SequenceTriggerTiles and SequenceTriggerIDs lists must have the same number of elements.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is in the AddAttempt tiles list
        if (addAttemptTiles.Contains(other.gameObject))
        {
            AddAttempt();
        }

        // Check if the object is in the SequenceTrigger tiles list
        int index = sequenceTriggerTiles.IndexOf(other.gameObject);
        if (index != -1)
        {
            ProcessTrigger(sequenceTriggerIDs[index]);
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
            attempts = 0; // Reset attempts after resetting items
        }
    }

    private void ProcessTrigger(int triggerID)
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
