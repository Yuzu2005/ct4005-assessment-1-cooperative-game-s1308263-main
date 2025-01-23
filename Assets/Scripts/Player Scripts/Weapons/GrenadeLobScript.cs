using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLobScript : MonoBehaviour {

    [SerializeField] private float lobUp = 100f;
    [SerializeField] private float lobForward = 100f;
    [SerializeField] private GameObject grenade;


    //Adds velocity to grenade after spawned
    private void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = (transform.forward * lobForward) + (transform.up * lobUp) * Time.deltaTime;
    }
}

//Script by Jacob