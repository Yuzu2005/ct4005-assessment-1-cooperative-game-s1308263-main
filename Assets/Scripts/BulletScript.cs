using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    [SerializeField] private float bulletSpeed = 1000;

    //sets bullet veolcity every frame
    private void Update() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }

    //destroy bullet on collision with anything
    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}

//Script by Jacob