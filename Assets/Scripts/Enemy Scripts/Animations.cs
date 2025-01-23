using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;
    
    public void Anims() {
        //gets the animator on the character and plays the standreload animation
        Animator anims = GetComponent<Animator>();
        anims.Play("standreload");
    }
    public void Melee() {
        //gets the animator on the character and plays the Standing Torch Melee Attack Stab animation
        Animator anims = GetComponent<Animator>();
        anims.Play("Standing Torch Melee Attack Stab");
    }
    public void TankBoss() {
        //gets the animator on the character and plays the Standing Torch Melee Attack Stab animation
        Animator anims = GetComponent<Animator>();
        anims.Play("");
    }
}
