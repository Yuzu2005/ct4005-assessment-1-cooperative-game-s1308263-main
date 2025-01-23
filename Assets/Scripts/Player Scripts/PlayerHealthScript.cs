using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEditor.SceneManagement;

public class PlayerHealthScript : MonoBehaviour {

    [SerializeField] private GameObject playerModel, healthTextObj;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Material transparent, origMat;
    [SerializeField] private Transform tank;

    [SerializeField] private float hitMatTimer = 0.2f;
    [SerializeField] private int invincSeconds = 3;
    [SerializeField] private int maxHealth = 3;
    public int currentHealth;

    public bool isInvinc, isAlive = true;

    private Color origCol;
    private float dieTimer = 2f;
    private CharacterController CharCon;
    private PlayerMovement PlayMove;
    private Shoot shoot;

    private void Awake() {
        //remove a shared life on spawn
        FindObjectOfType<SharedLives>().lives--;
        isAlive = true;
        currentHealth = maxHealth;
        healthText.SetText("Health: " + currentHealth);
        origCol = playerModel.GetComponent<MeshRenderer>().material.color;
        CharCon = GetComponent<CharacterController>();
        PlayMove = GetComponent<PlayerMovement>();
        shoot = GetComponent<Shoot>();
    }

    private void Update() {
        Debug.Log("Health: " + currentHealth);
        //reset everything on player death
        if (currentHealth <= 0) {
            currentHealth = 0;
            CharCon.enabled = false;
            PlayMove.enabled = false;
            shoot.enabled = false;
            healthTextObj.SetActive(false);
            TryGetComponent<Shoot>(out Shoot shootRef);
            shootRef.StopAllCoroutines();
            shootRef.hasFlamePickup = false;
            shootRef.hasRPGPickup = false;
            FindObjectOfType<MultipleTargetCamera>().RemovePlayer(transform);
            if (isAlive == false) {
                playerModel.GetComponent<PlayerAnimations>().DieAnim();
                if (dieTimer <= 0) {
                    Destroy(gameObject);
                    FindObjectOfType<SharedLives>().RemoveLife();
                }
            }
            dieTimer -= 1 * Time.deltaTime;
            isAlive = false;
        }
    }

    public void OnCollisionEnter(Collision collision) {
        //remove health on collision with bullet
        if (collision.transform.CompareTag("Bullet")) {
            if (isInvinc == false) {
                RemoveHealth();
                healthText.SetText("Health: " + currentHealth);
            }
        }
        //Added by Will
        else if (collision.transform.CompareTag("TankBullet")) {
            RemoveHealth();
            healthText.SetText("Health: " + currentHealth);
        }
        //Added by Will
        else if (collision.transform.CompareTag("HitBox")) {
            RemoveHealth();
            healthText.SetText("Health: " + currentHealth);
        }
    }

    //remove health from player
    public void RemoveHealth() {
        TryGetComponent<Shoot>(out Shoot shotNo);
        shotNo.hasShotgunPickup = false;
        shotNo.isShotgun = false;
        currentHealth--;
        if (currentHealth <= 0) {
            isAlive = false;
        }
        healthText.SetText("Health: " + currentHealth);
        StartCoroutine("InvincTimer");
        DamageFlash();
    }

    //Add health to player
    public void AddHealth() {
        if (currentHealth < 3) {
            currentHealth++;
            healthText.SetText("Health: " + currentHealth);
        }
    }

    //Player invincible timer
    IEnumerator InvincTimer() {
        isInvinc = true;
        Debug.Log("Player is Invincible");
        playerModel.GetComponent<MeshRenderer>().material = transparent;
        yield return new WaitForSeconds(invincSeconds);
        isInvinc = false;
        playerModel.GetComponent<MeshRenderer>().material = origMat;
        Debug.Log("Player is NOT Invincible");
    }

    //damage flash when hit
    private void DamageFlash() {
        playerModel.GetComponent<MeshRenderer>().material.color = Color.white;
        Invoke("FlashStop", hitMatTimer);
    }

    //stop damage flash
    private void FlashStop() {
        playerModel.GetComponent<MeshRenderer>().material.color = origCol;
    }
}

//Script by Jacob