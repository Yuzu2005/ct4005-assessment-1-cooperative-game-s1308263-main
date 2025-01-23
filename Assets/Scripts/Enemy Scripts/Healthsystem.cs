using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Healthsystem : MonoBehaviour {

    [SerializeField] private GameObject grenadePickup, healthPickup, flamePickup, shotgunPickup, RPGPickup;

    public float Health;
    //[SerializeField] private GameObject tankpiece;

    private void Awake() {
        FindObjectOfType<AISpawner>().AddEnemy(transform);
    }
    public void OnCollisionEnter(Collision collision) {
        //if the object was hit by another game object with the tag Bullet
        if (collision.gameObject.CompareTag("Bullet")) {
            RemoveHealthEnBullet();
        }
    }

    private void OnParticleCollision(GameObject ParticleCol) {
        if (ParticleCol.gameObject.CompareTag("Flamethrower")) {
            Health -= 1f;
            if (Health <= 0f) {
                FindObjectOfType<AISpawner>().RemoveEnemy(transform);
                StartCoroutine("PickupDrop");
                Destroy(gameObject);
            }
            else if (ParticleCol.gameObject == null) {
                return;
            }
        }
    }

    public void RemoveHealthEnBullet() {
        //reduce health by 5 and if 0 destroy the game object the script is attached to
        Health -= 5f;
        if (Health <= 0f)
        {
            FindObjectOfType<AISpawner>().RemoveEnemy(transform);
            StartCoroutine("PickupDrop");
            Destroy(gameObject);
            //tankpiece.GetComponent<destroytankHead>().Destroytank();
        }
    }

    public void RemoveHealthEnExplo() {
        //reduce health by 5 and if 0 destroy the game object the script is attached to
        Health -= 100f;
        if (Health <= 0f) {
            FindObjectOfType<AISpawner>().RemoveEnemy(transform);
            StartCoroutine("PickupDrop");
                Destroy(gameObject);
            //tankpiece.GetComponent<destroytankHead>().Destroytank();
        }
    }

    public void RemoveHealthFlame() {
        //reduce health by 5 and if 0 destroy the game object the script is attached to
        Health -= 1f;
        if (Health <= 0f) {
            FindObjectOfType<AISpawner>().RemoveEnemy(transform);
            StartCoroutine("PickupDrop");
            Destroy(gameObject);
            //tankpiece.GetComponent<destroytankHead>().Destroytank();
        }
    }

    //(Added by Jacob)   Drops a pickup randomly
    private IEnumerator PickupDrop() {
        int randNum = Random.Range(0, 20);
        Vector3 pickupSpawnPos = gameObject.transform.position;
        if (randNum == 1) {
            var grenadePickupClone = Instantiate(grenadePickup, pickupSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20);
            Destroy(grenadePickupClone);
        }
        else if (randNum == 2) {
            var healthPickupClone = Instantiate(healthPickup, pickupSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20);
            Destroy(healthPickupClone);
        }
        else if (randNum == 3) {
            var flamePickupClone = Instantiate(flamePickup, pickupSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20);
            Destroy(flamePickupClone);
        }
        else if (randNum == 4) {
            var shotgunPickupClone = Instantiate(shotgunPickup, pickupSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20);
            Destroy(shotgunPickupClone);
        }
        else if (randNum == 5) {
            var RPGPickupClone = Instantiate(RPGPickup, pickupSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20);
            Destroy(RPGPickupClone);
        }
    }

    // Update is called once per frame
    public void Update() {
    }
}
