using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerPickup : MonoBehaviour {

    //Flamethrower pickup
    private void OnTriggerEnter(Collider flameCol) {
        if (flameCol.transform.CompareTag("Player")) {
            Debug.Log("FlamePickup hit player");
            if (FindObjectOfType<Shoot>().hasRPGPickup == false) {
                if (FindObjectOfType<Shoot>().hasFlamePickup == false) {
                    //insert pickup audio here
                    flameCol.TryGetComponent<Shoot>(out Shoot flame);
                    flameCol.TryGetComponent<FlamethrowerFuel>(out FlamethrowerFuel gas);
                    flame.hasFlamePickup = true;
                    gas.fuel = 100;
                    Destroy(gameObject);
                    Debug.Log("Flamethrower Added");
                }
            }
        }
    }
}

//Script by Jacob