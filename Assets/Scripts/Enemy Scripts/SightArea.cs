using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightArea : MonoBehaviour
{
    //[SerializeField] private GameObject Shooter;
    [SerializeField] private GameObject Shooter;
    
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //call to the checklook function in the shooterai script
            Shooter.GetComponent<ShooterAI>().Checklooktrue();
            
        }
    }
    public void OnTriggerExit(Collider other) {
        
        if (other.CompareTag("Player")) {
            Shooter.GetComponent<ShooterAI>().Checklookfalse();
        }
    }
}
