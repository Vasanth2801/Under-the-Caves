using UnityEngine;

public class OctopusEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float bulletForce = 10f;
    [SerializeField] private float shootingRange = 10f;

    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePoint;
    ObjectPooler pooler;

    [Header("Shooting Settings")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float nextFireTime;

    void Start()
    {
        pooler = FindObjectOfType<ObjectPooler>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if(distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = pooler.SpawnFromPools("EnemyBullet", firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}