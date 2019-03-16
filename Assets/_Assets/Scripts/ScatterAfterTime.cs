using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterAfterTime : MonoBehaviour
{
    public GameObject scatterFragments;
    public GameObject bulletContainer;
    public float time = 5;
    public float fragmentsLifeTime = 4;
    public int scatterCount = 5;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("ScatterAfterTime: no scatterFragments ref set.");

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
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            scatter();
        }

    }

    private void scatter()
    {
        for (int i = 0; i < scatterCount; i++)
        {
            GameObject projectile = Instantiate(scatterFragments, transform.position, transform.rotation, bulletContainer.transform);
            if (projectile.GetComponent<Rigidbody>() == null)
            {
                projectile.AddComponent<Rigidbody>();
            }
            projectile.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity * -1 * 0.6f + Random.onUnitSphere * speed;
            if (projectile.GetComponent<DestroyAferTime>() == null)
            {
                projectile.AddComponent<DestroyAferTime>();
            }
            projectile.GetComponent<DestroyAferTime>().time = fragmentsLifeTime;
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        scatter();
    }

}
