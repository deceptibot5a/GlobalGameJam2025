using UnityEngine;

[System.Serializable]

public class Shoot : MonoBehaviour
{

    [SerializeField] private float cooldownTime;
    [SerializeField] Animator animator;
    private float _nextFireTime;

    bool hasAmmo;
    public bool  CoolingDown=> Time.time < _nextFireTime;
    public void StartCoolDown() => _nextFireTime = Time.time + cooldownTime;

    public Rigidbody bubble;

    public float bola = 300;

    public void disparo()
    {
        StaticEventHandler.UseAmmonition();
        if (CoolingDown) return;

        animator.SetTrigger("ShootAnim");
        var projectile = Instantiate(bubble, transform.position, transform.rotation);

        projectile.linearVelocity = transform.forward * bola;

        StartCoolDown();
    }
    private void OnEnable()
    {
        StaticEventHandler.OnGivenAmmo += GiveAmmo;
        StaticEventHandler.OnUseAmmo += UseAmmo;
    }
    private void OnDisable()
    {
        StaticEventHandler.OnGivenAmmo -= GiveAmmo;
        StaticEventHandler.OnUseAmmo -= UseAmmo;
    }
    void GiveAmmo()
    {
        hasAmmo=true;
    }
    void UseAmmo()
    {
        hasAmmo = false;
    }
    void Start()
    {
        hasAmmo = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& hasAmmo)
        {
            disparo();
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("BreakAnim");
        }
    }



}
