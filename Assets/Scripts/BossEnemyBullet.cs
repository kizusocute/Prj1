using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBullet : MonoBehaviour
{
    public float bossEnemyBulletDamage = 10f;
    private Vector3 movementDirection;

    void Start()
    {
        Destroy(gameObject, 1f);
    }
    void Update()
    {
        if (movementDirection == Vector3.zero) return;
        transform.position += movementDirection * Time.deltaTime;
    }

    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }
}
