using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage/2);
        }
    }

    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
