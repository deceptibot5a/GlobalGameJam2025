using UnityEngine;

public class HazardShoot : MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    [SerializeField] int speed;
    float counter = 0;

    void Update()
    {
        if(counter >= 3)
        {
            var projectile = Instantiate(bullet, transform.position, transform.rotation);
            projectile.linearVelocity = transform.forward * speed;

            counter = 0;
        }
        counter += Time.deltaTime;
    }
}
