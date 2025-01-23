using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSight : MonoBehaviour
{
    [SerializeField] private GameObject Tank;
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //call to the checklook function in the monsterai script
            Tank.GetComponent<Tank>().Checklooktrue();
        }
    }
    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Tank.GetComponent<Tank>().Checklookfalse();
        }
    }
}
