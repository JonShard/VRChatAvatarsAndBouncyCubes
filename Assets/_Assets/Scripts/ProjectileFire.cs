using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    public GameObject barrelTip;
    public GameObject bullet;
    public GameObject bulletContainer;
    [Range(1, 100)]
    public int bulletsPerShot = 1;
    public float speed = 5;
    public float spread = 0;
    [Range(0, 20)]
    public float fireRate = 0.15f;
    public bool  isFireing {get;set;}

    [HideInInspector]
    public float spreadPenalty = 0;
    private float timeToFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (barrelTip == null)
        {
            barrelTip = transform.Find("BarrelTip").gameObject;
            if (barrelTip == null)
            {
                barrelTip = gameObject;
            }
        }
        if (bullet == null)
        {
            bullet = gameObject;
            Debug.LogError("ProjectileFire without bulletPrefab ref. Can not fire nothing.");
        }
        if (bulletContainer == null)
        {
            bulletContainer = GameObject.Find("BulletContainer").gameObject;
            if (bulletContainer == null)
            {
                Debug.LogWarning("ProjectileFire without bulletContainer ref. Can not fire nothing.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToFire > 0)
        {
            timeToFire -= Time.deltaTime;
        }

        if (isFireing && timeToFire <= 0)
        {
            timeToFire = fireRate;
            for (int i = 0; i < bulletsPerShot; i++)
            {
                GameObject projectile = Instantiate(bullet, barrelTip.transform.position, barrelTip.transform.rotation, bulletContainer.transform);
                if (projectile.GetComponent<Rigidbody>() == null)
                {
                    projectile.AddComponent<Rigidbody>();
                }
                projectile.GetComponent<Rigidbody>().velocity = barrelTip.transform.forward * speed + Random.onUnitSphere * spread;
            }
        }
    }
}
