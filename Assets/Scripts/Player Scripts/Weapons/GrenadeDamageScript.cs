using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDamageScript : MonoBehaviour
{
    [SerializeField] private GameObject grenDamTrigger;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip exploClip;
    [SerializeField] private float explosionForce = 100;
    [SerializeField] private float explosionRadius = 100;

    private float countdownTimer = 3f;
    private float fireballTimer = 3f;

    bool hasExploded;

    //uses explode physics to calculate damage
    void Update() {
        countdownTimer -= 1 * Time.deltaTime;
        if (countdownTimer <= 0) {
            Vector3 grenPos = transform.position;
            //Insert Audio of explosion
            Collider[] colliders = Physics.OverlapSphere(grenPos, explosionRadius);
            source.PlayOneShot(exploClip);
            foreach (Collider hit in colliders) {
                //sets grenade damage for enemy
                if (hit.transform.CompareTag("Enemy")) {
                    if (hit.transform.TryGetComponent<Healthsystem>(out Healthsystem enGrenExplo)) {
                        enGrenExplo.RemoveHealthEnExplo();
                    }
                    Debug.Log("enemy Damaged: grenade");
                }
                //sets grenade damage for player
                else if (hit.transform.TryGetComponent<PlayerHealthScript>(out PlayerHealthScript plGrendam)) {
                    plGrendam.RemoveHealth();
                    Debug.Log("player damaged: grenade");
                }
                //sets grenade damage for explosive barrel
                else if (hit.transform.TryGetComponent<ExplodingBarrel>(out ExplodingBarrel comp)) {
                    comp.RemoveHealth();
                }
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null) {
                    rb.AddExplosionForce(explosionForce, grenPos, explosionRadius, 5);
                    hasExploded = true;
                    if (hasExploded == true) {
                        hasExploded = false;
                    }
                }
            }
            //spawns explosion particles
            var cloneTrigger = Instantiate(grenDamTrigger, grenPos, transform.rotation);
            Destroy(gameObject);
            if (fireballTimer <= 0) {
                Destroy(cloneTrigger);
                fireballTimer = 3f;
            }
        }
        
    }
}

//Script by Jacob