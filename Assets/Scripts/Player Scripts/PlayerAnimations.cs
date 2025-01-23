using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public GameObject playerModel;

    //Player animation list
    public void Idle() {
        playerModel.GetComponent<Animator>().Play("RifleAimingIdle");
    }

    public void ForwardRun() {
        playerModel.GetComponent<Animator>().Play("RunForwards");
    }
    public void ForwardLeftRun()
    {
        playerModel.GetComponent<Animator>().Play("RunningForwardLeft");
    }
    public void ForwardRightRun()
    {
        playerModel.GetComponent<Animator>().Play("RunningForwardRight");
    }
    public void BackwardRun()
    {
        playerModel.GetComponent<Animator>().Play("RunBackwards");
    }
    public void BackwardLeftRun()
    {
        playerModel.GetComponent<Animator>().Play("RunningBackwardsLeft");
    }

    public void BackwardRightRun()
    {
        playerModel.GetComponent<Animator>().Play("RunningBackwardsRight");
    }

    public void LeftRun()
    {
        playerModel.GetComponent<Animator>().Play("RunningLeft");
    }

    public void RightRun()
    {
        playerModel.GetComponent<Animator>().Play("RunningRight");
    }

    public void Dodge() {
        playerModel.GetComponent<Animator>().Play("RunningDiveRoll");
    }

    public void GrenadeThrowIdle() {
        playerModel.GetComponent<Animator>().Play("TossGrenade");
    }

    public void GrenadeThrowRun() {
        playerModel.GetComponent<Animator>().Play("RunningGrenadeThrow");
    }

    public void DieAnim() {
        playerModel.GetComponent<Animator>().Play("Dying");
    }
}

//Script by Jacob