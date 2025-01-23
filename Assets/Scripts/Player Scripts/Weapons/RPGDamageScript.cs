using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RPGDamageScript : MonoBehaviour {

    [SerializeField] private GameObject grenDamTrigger;

    [SerializeField] private float explosionForce = 100;
    [SerializeField] private float explosionRadius = 100;
    [SerializeField] private float rpgSpeed = 1000;

    private bool hasExploded;

    //sets RPG velocity every frame
    private void Update() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * rpgSpeed;
    }

    //uses explode physics to calculate damage
    private void OnCollisionEnter(Collision collision) {
        Vector3 ExploPos = gameObject.transform.position;
        var cloneTrigger = Instantiate(grenDamTrigger, ExploPos, transform.rotation);
        //Insert Audio of explosion
        hasExploded = true;
        Collider[] colliders = Physics.OverlapSphere(ExploPos, explosionRadius);
        foreach (Collider hit in colliders) {
            //sets RPG damage for enemy
            if (hit.transform.CompareTag("Enemy")) {
                if (hit.transform.TryGetComponent<Healthsystem>(out Healthsystem enGrenExplo)) {
                    enGrenExplo.RemoveHealthEnExplo();
                }
                Debug.Log("enemy Damaged: RPG");
            }
            //sets RPG damage for player
            else if (hit.transform.TryGetComponent<PlayerHealthScript>(out PlayerHealthScript plGrendam)) {
                plGrendam.RemoveHealth();
                Debug.Log("player damaged: RPG");
            }
            //sets RPG damage for Boss
            else if (hit.transform.TryGetComponent<BossHealth>(out BossHealth tank)) {
                tank.RemoveHealthExplosion();
                Debug.Log("tank damaged: RPG");
            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce, ExploPos, explosionRadius, 5);
                hasExploded = true;
                if (hasExploded == true) {
                    hasExploded = false;
                }
            }
        }
        Destroy(cloneTrigger);
        Destroy(gameObject);
    }
}

//Script by Jacob