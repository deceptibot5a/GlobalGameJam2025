using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] GameObject boomEffect;
    [SerializeField] AudioSource soundEffect;
    [SerializeField] Animator animator;

    public void ActivateExplosion()
    {
        boomEffect.SetActive(true);
        soundEffect.PlayOneShot(soundEffect.clip);
        animator.SetTrigger("Interact");
    }
}
