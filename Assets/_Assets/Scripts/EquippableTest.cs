using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRCSDK2;

public class EquippableTest : MonoBehaviour {

    VRC_Pickup pickup;
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        pickup = GetComponent<VRC_Pickup>();
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pickup.IsHeld)
        {
        }
        Destroy(gameObject);

    }


}
