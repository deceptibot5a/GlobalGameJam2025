using UnityEngine;

[System.Serializable]

public class Shoot : MonoBehaviour
{

    [SerializeField] private float cooldownTime;
    private float _nextFireTime;

    public bool  CoolingDown=> Time.time < _nextFireTime;
    public void StartCoolDown() => _nextFireTime = Time.time + cooldownTime;

    public Rigidbody bubble;

    public float bola = 300;

    public void disparo()
    {
        if (CoolingDown) return;
        var projectile = Instantiate(bubble, transform.position, transform.rotation);

        projectile.linearVelocity = transform.forward * bola;

        StartCoolDown();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         if (Input.GetMouseButtonDown(0))
            {
            disparo();
            }
        
    }



}
