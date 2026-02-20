using UnityEngine;

public class EnemyBullet : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Playerhealth playerHealth = collision.gameObject.GetComponent<Playerhealth>();
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            }
        }
        gameObject.SetActive(false);
    }
}