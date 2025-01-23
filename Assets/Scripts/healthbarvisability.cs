using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class healthbarvisability : MonoBehaviour
{
    public GameObject healthbar;
    private void OnTriggerEnter(Collider other) {
        //if an object with the player tag overlaps with trigger show the healthbar
        if (other.transform.CompareTag("Player")) {
            healthbar.SetActive(true);
        }
    }
}
