using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : MonoBehaviour {

    //grenade pickup
    private void OnTriggerEnter(Collider grenCol) {
        if (grenCol.gameObject.transform.CompareTag("Player")) {
            if (grenCol.transform.TryGetComponent<Shoot>(out Shoot shootScript)) {
                if (shootScript.GrenAmount < 3) {
                    //insert pickup audio here
                    shootScript.AddGrenade();
                    Destroy(gameObject);
                    Debug.Log("Grenade Added");
                }
            }
        }
    }
}

//Script by Jacob