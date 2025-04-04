using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManger audioManger;
    [SerializeField] private UIManager uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            BossEnemyBullet bossEnemyBullet = collision.GetComponent<BossEnemyBullet>();
            PlayerController player = GetComponent<PlayerController>();
            player.TakeDamage(bossEnemyBullet.bossEnemyBulletDamage);
            Destroy(collision.gameObject);
        }else if (collision.CompareTag("Usb"))
        {
            uiManager.WinGame();
            uiManager.fightBoss.SetActive(false);
            Destroy(collision.gameObject);
        }else if (collision.CompareTag("Energy"))
        {
            gameManager.AddEnergy();
            audioManger.PlayEnergySound();
            Destroy(collision.gameObject);
        }

    }
}
