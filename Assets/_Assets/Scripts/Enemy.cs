using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public int lives = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.GetComponent<DestroyAferTime>() == null)
        {
            lives--;
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosion);
    }
}
