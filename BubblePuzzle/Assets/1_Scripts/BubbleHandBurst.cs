using UnityEngine;

public class BubbleHandBurst : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMeshRenderer;
    private void OnEnable()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.enabled = false;
        StaticEventHandler.OnGivenAmmo += ShowMesh;
        StaticEventHandler.OnUseAmmo += HideMesh;
    }
    private void OnDisable()
    {
        StaticEventHandler.OnGivenAmmo -= ShowMesh;
        StaticEventHandler.OnUseAmmo -= HideMesh;
    }

    void ShowMesh()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.enabled = true;
    }

    void HideMesh()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.enabled = false;
    }


}
