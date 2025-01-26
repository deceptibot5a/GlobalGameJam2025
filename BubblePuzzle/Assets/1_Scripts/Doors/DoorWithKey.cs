using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public bool isLocked = true;
    MeshDestroy meshDestroy; 

    private void Start()
    {
        meshDestroy = GetComponent<MeshDestroy>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLocked == false)
            {
                meshDestroy.DestroyMesh();
            }
        }
    }
}
