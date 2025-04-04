using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] public float shotDelay = 0.05f;
    [SerializeField] int maxAmmo = 30;
    public int currentAmmo;
    private float nextShot;

    [SerializeField]private TextMeshProUGUI ammoText;
    [SerializeField] private AudioManger audioManger;

    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Shoot();
        Reload();
    }

    void RotateGun()
    {
        CheckMouseInScreen();
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        if(angle <-90 || angle > 90)
        {
            transform.localScale = new Vector3(0.66f, 0.66f, 1);
        }
        else
        {
            transform.localScale = new Vector3(0.66f, -0.66f, 1);
        }
    }
    void CheckMouseInScreen()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x  > Screen.width  || Input.mousePosition.y < 0 || Input.mousePosition.y > 0)
        {
            return;
        }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
            currentAmmo--;
            UpdateAmmo();
            audioManger.PlayShootSound();
        }
    }

    void Reload()
    {
        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            UpdateAmmo();
            audioManger.PlayReloadSound();
        }
    }
    private void UpdateAmmo()
    {
        if (ammoText != null)
        {
            if (currentAmmo >= 0)
            {
                ammoText.text = currentAmmo.ToString();
            }
            else
            {
                ammoText.text = "Reload";
            }
        }
    }
}


