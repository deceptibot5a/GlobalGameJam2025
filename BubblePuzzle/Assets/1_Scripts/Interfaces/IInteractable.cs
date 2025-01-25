using UnityEngine;

public interface IInteractable
{
    void InteractedWith();
    void Vanish();
    void Resize(float amount);
    void Instance();
    void GenerateHUDRendder();
}
