using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamTrigger : MonoBehaviour {

    [SerializeField] private Transform tank;
    [SerializeField] private GameObject healthBar, healthText;
    [SerializeField] private AudioSource bossMusic;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            FindObjectOfType<MultipleTargetCamera>().AddPlayer(tank.transform);
            healthBar.SetActive(true);
            healthText.SetActive(true);
            bossMusic.Play();
            Destroy(gameObject);
        }
    }
}
