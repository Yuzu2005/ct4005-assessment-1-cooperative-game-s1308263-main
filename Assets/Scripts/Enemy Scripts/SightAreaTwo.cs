using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightAreaTwo : MonoBehaviour
{
    //[SerializeField] private GameObject Shooter;
    [SerializeField] private GameObject Fighter;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //call to the checklook function in the monsterai script
            
            Fighter.GetComponent<MonsterAI>().Checklooktrue();
        }
    }
    public void OnTriggerExit(Collider other) {

        if (other.CompareTag("Player")) {
            
            Fighter.GetComponent<MonsterAI>().Checklookfalse();
        }
    }
}
