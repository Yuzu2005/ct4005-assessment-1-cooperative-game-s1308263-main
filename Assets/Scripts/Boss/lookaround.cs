using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lookaround : MonoBehaviour {
    
    List<Transform> Playertypes = new List<Transform>();
    private float timer = 7f;
    private float AddToTimer = 0.5f;
    [SerializeField] private float rotateTime = 10f;
    private int playerrand;
    
    void Update() {
        Debug.Log(Playertypes);
        Addplayer();
        lookplayer();
        chooserandom();
    }
    private void Addplayer() {
        GameObject[] AllPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in AllPlayers) {
            //adds 1 to playertypes for every gameobject with the player tag
            Playertypes.Add(player.transform);
            if(player == null) {
                Playertypes.Remove(player.transform);
            }
        }
    }
    private void chooserandom() {
        timer -= AddToTimer * Time.deltaTime;
        Debug.Log(timer);
        if (timer <= 0f) {
            timer = 0f;
            playerrand = Random.Range(0, Playertypes.Count);
            timer = 7f;
        }
    }
    private void lookplayer() {
        foreach (Transform player in Playertypes) {
            if (player == null) {
            }
            //if the amount is higher or equal to 1 get a the random range from chooserandom and look at them
            else if(Playertypes.Count >= 0) {
                
                transform.LookAt(Playertypes[playerrand]);  //Playertypes[playerrand]
                Debug.Log("play" + playerrand);
            }
        }
    }
}
