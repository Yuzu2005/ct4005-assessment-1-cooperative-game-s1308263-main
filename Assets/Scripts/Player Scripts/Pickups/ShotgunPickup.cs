using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : MonoBehaviour {

    //Shotgun pickup
    private void OnTriggerEnter(Collider shotgunCol) {
        if (shotgunCol.transform.CompareTag("Player")) {
            Debug.Log("ShotgunPickup hit player");
            if (FindObjectOfType<Shoot>().hasShotgunPickup == false) {
                //insert pickup audio here
                shotgunCol.TryGetComponent<Shoot>(out Shoot shotgun);
                shotgun.hasShotgunPickup = true;
                Destroy(gameObject);
                Debug.Log("Shotgun Added");
            }
        }
    }
}

//Script by Jacob