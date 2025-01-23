using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

    public bool canSpawn = true;

    //if a player is in trigger, another player cannot spawn there
    private void OnTriggerEnter(Collider spawnCol) {
        if (spawnCol.CompareTag("Player")) {
            canSpawn = false;
        }
    }
}

//Script by Jacob