using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{

    [SerializeField] private GameObject grenDamTrigger;
    [SerializeField] private GameObject EnemyShoot;
    [SerializeField] private GameObject EnemyMelee;

    [SerializeField] private float explosionForce = 100;
    [SerializeField] private float explosionRadius = 100;

    public int barrelHealth = 1;

    bool hasExploded;

    public void OnCollisionEnter(Collision collision){
        //explode barrel on bullet collision
        if (collision.transform.CompareTag("Bullet")){
            RemoveHealth();
        }
    }

    private void Update() {
        if (barrelHealth <= 0) {
            //explode barrel on health = 0
            Vector3 ExploPos = gameObject.transform.position;
            var cloneTrigger = Instantiate(grenDamTrigger, ExploPos, transform.rotation);
            //Insert Audio of explosion
            hasExploded = true;
            Collider[] colliders = Physics.OverlapSphere(ExploPos, explosionRadius);
            foreach (Collider hit in colliders) {
                //damage enemy
                if (hit.transform.CompareTag("Enemy")) {
                    if (hit.transform.TryGetComponent<Healthsystem>(out Healthsystem enGrenExplo)) {
                        enGrenExplo.RemoveHealthEnExplo();
                    }
                    Debug.Log("enemy Damaged: RPG");
                }
                //damage player
                else if (hit.transform.TryGetComponent<PlayerHealthScript>(out PlayerHealthScript plGrendam)) {
                    plGrendam.RemoveHealth();
                    Debug.Log("player damaged: grenade");
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

    //remove barrel health
    public void RemoveHealth(){
        barrelHealth--;
    }
}

//Script by Jacob