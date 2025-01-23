using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeParticle : MonoBehaviour {

    [SerializeField] private GameObject exploParticle;
    [SerializeField] private GameObject exploTrigger;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip exploClip;

    //play particles on awake
    private void Awake() {
        StartCoroutine("PlayExplo");
    }

    //particle instantiation
    IEnumerator PlayExplo() {
        source.PlayOneShot(exploClip);
        var partClone = Instantiate(exploParticle, exploTrigger.transform.position, transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(partClone);
    }
}

//Script by Jacob