using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public GameObject tankboss;
    public GameObject slider;
    public Slider healthSlider;
    public float Health;
    
    [SerializeField]private GameObject healthui, bossHealthObj;
    public TMP_Text bossHealthText;
    bool TankBaseWasDestroyed = false;

    private void Update() {
        bossHealthText.SetText("Health: " + Health);
        healthSlider.value = Health;
    }
    

    public void OnCollisionEnter(Collision collision) {
        //if the object was hit by another game object with the tag Bullet
        if (collision.gameObject.CompareTag("Bullet")) {
            RemoveHealthEnBullet();
        }
    }
    private void OnParticleCollision(GameObject ParticleCol) {
        if (ParticleCol.gameObject.CompareTag("Flamethrower")) {
            Health -= 0.5f;
            if (healthSlider.value <= 0f) {
                Destroy(slider);
            }

            //if 0 destroy the game object the script is attached to
            if (Health <= 0f) {
                TankBaseWasDestroyed = true;
                FindObjectOfType<MultipleTargetCamera>().RemovePlayer(gameObject.transform);
                SceneManager.LoadScene("GameOverWin");
                Destroy(gameObject);
                
            }
            //if the tankbase is destroyed destroy the parent of it so everything else in the same prefab is destroyed
            if (TankBaseWasDestroyed == true) {
                healthui.SetActive(false);
                FindObjectOfType<MultipleTargetCamera>().RemovePlayer(tankboss.transform);
                SceneManager.LoadScene("GameOverWin");
                Destroy(tankboss);
            }
            else if (ParticleCol.gameObject == null) {
                return;
            }
        }
    }
    public void RemoveHealthEnBullet() {
        Health -= 5f;
        if (healthSlider.value <= 0f) {
            Destroy(slider);
        }

        //if 0 destroy the game object the script is attached to
        if (Health <= 0f) {
            TankBaseWasDestroyed = true;
            FindObjectOfType<MultipleTargetCamera>().RemovePlayer(gameObject.transform);
            SceneManager.LoadScene("GameOverWin");
            Destroy(gameObject);
        }
        //if the tankbase is destroyed destroy the parent of it so everything else in the same prefab is destroyed
        if (TankBaseWasDestroyed == true) {
            healthui.SetActive(false);
            FindObjectOfType<MultipleTargetCamera>().RemovePlayer(tankboss.transform);
            SceneManager.LoadScene("GameOverWin");
            Destroy(tankboss);
        }
    }
    public void RemoveHealthExplosion() {
        //reduce health by 100 and if 0 destroy the game object the script is attached to
        Health -= 10f;
        if (healthSlider.value <= 0f) {
            Destroy(slider);
        }

        //if 0 destroy the game object the script is attached to
        if (Health <= 0f) {
            TankBaseWasDestroyed = true;
            FindObjectOfType<MultipleTargetCamera>().RemovePlayer(gameObject.transform);
            SceneManager.LoadScene("GameOverWin");
            Destroy(gameObject);
        }
        //if the tankbase is destroyed destroy the parent of it so everything else in the same prefab is destroyed
        if (TankBaseWasDestroyed == true) {
            healthui.SetActive(false);
            FindObjectOfType<MultipleTargetCamera>().RemovePlayer(tankboss.transform);
            SceneManager.LoadScene("GameOverWin");
            Destroy(tankboss);
        }
    }

}