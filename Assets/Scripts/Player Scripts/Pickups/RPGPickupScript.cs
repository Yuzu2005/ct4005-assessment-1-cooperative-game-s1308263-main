using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPickupScript : MonoBehaviour {

    //RPG pickup
    private void OnTriggerEnter(Collider rPGCol) {
        if (rPGCol.transform.CompareTag("Player")) {
            Debug.Log("RPGPickup hit player");
            if (FindObjectOfType<Shoot>().hasFlamePickup == false) {
                if (FindObjectOfType<Shoot>().hasRPGPickup == false) {
                    //insert pickup audio here
                    rPGCol.TryGetComponent<Shoot>(out Shoot rPG);
                    rPG.RPGAmmo = 5;
                    rPG.hasRPGPickup = true;
                    Destroy(gameObject);
                    Debug.Log("RPG Added");
                }
            }
        }
    }
}

//Script by Jacob