using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedBullet = 10f;
    [SerializeField] private float healValue = 5f;
    [SerializeField] GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 2f;
    private float nextSkillTime = 0f;
    [SerializeField] private GameObject usbPrefabs;

    protected override void Update()
    {
        base.Update();
        if (Time.time > nextSkillTime)
        {
            UseSkill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(stayDamage);
            }
        }
    }

    private void BanDanThuong()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            BossEnemyBullet bossEnemyBullet = bullet.AddComponent<BossEnemyBullet>();
            bossEnemyBullet.SetMovementDirection(directionToPlayer * speedBullet);
        }
    }
    private void BanDanVongTron()
    {
        const int bulletCount = 12;
        float angleStep = 360 / bulletCount;
        for(int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            BossEnemyBullet bossEnemyBullet = bullet.AddComponent<BossEnemyBullet>();
            bossEnemyBullet.SetMovementDirection(bulletDirection * speedBullet);
        }
    }
    private void Heal(float hpAmount)
    {
        currentHp = Mathf.Min(currentHp + hpAmount, maxHp);
        UpdateHpBar();
    }
    private void SpawnMiniEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }

    private void TeleportToPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }

    private void ChooseRandomSkill()
    {
        int randomSkill = UnityEngine.Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                Heal(healValue);
                break;
            case 3:
                SpawnMiniEnemy();
                break;
            case 4:
                TeleportToPlayer();
                break;

        }
    }
    private void UseSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        ChooseRandomSkill();
    }
    protected override void Die()
    {
        Instantiate(usbPrefabs, transform.position, Quaternion.identity);
        base.Die();
    }
}
