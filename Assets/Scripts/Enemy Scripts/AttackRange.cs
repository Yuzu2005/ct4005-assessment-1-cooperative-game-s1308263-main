using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject Box;
    public void OnTriggerStay(Collider Character) {
        //while the player is in the triggerbox it will cast to
        if (Character.gameObject.CompareTag("Player")) {
            Box.GetComponent<Animations>().Melee();
        }
    }
    
}
