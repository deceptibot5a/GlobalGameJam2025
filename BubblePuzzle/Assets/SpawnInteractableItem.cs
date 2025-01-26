using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab to spawn in the Inspector
    public Transform spawnPoint;    // Assign the specific spawn point in the Inspector
    private GameObject spawnedObject; // Reference to the spawned object

    // Called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Spawn the object at the specified spawn point
            if (spawnedObject == null && objectToSpawn != null && spawnPoint != null)
            {
                spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    // Called when another collider exits the trigger
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Destroy the spawned object
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
            }
        }
    }
}