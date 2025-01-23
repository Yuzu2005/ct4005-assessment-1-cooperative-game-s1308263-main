using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    //Health pickup
    private void OnTriggerEnter(Collider healthCol) {
        if (healthCol.transform.CompareTag("Player")) {
            if (healthCol.transform.TryGetComponent<PlayerHealthScript>(out PlayerHealthScript healthScript)) {
                if (healthScript.currentHealth < 3) {
                    //insert pickup audio here
                    healthScript.AddHealth();
                    Destroy(gameObject);
                    Debug.Log("Health Added");
                }
            }
        }
    }
}

//Script by Jacob