using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class MonsterAI : MonoBehaviour
{
    
    private Vector3 WalkTo;
    private bool PointerSet;
    private Vector3 ChasePlayer;

    public NavMeshAgent Nav;
    public float WalkingRange;
    public LayerMask floorlayer, playerlayer;
    public float PlayerHealth;
    public float timer;
    public bool playerInSight;
    List<Transform> Playertypes = new List<Transform>();
    private void Awake()
    {
        Nav = GetComponent<NavMeshAgent>();
    }
    private void Start() {
        GameObject[] AllPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in AllPlayers) {
            //adds 1 to playertypes for every gameobject with the player tag
            Playertypes.Add(player.transform);
            
        }

    }
    public void MovementMode() {
        if (PointerSet) {
            Nav.SetDestination(WalkTo);
        }
        if(!PointerSet) {
            SearchMode();
        }
        Vector3 WalkingDistance = transform.position - WalkTo;
        if(WalkingDistance.magnitude < 1f ) {
            PointerSet = false;
        }
    }
    private void SearchMode() {
        float AxisX = Random.Range(-WalkingRange, WalkingRange);
        float AxisZ = Random.Range(-WalkingRange, WalkingRange);
        WalkTo = new Vector3(transform.position.x + AxisX, transform.position.y, transform.position.z + AxisZ);
        if (Physics.Raycast(WalkTo, -transform.up, 2f, floorlayer)) {
            PointerSet = true;
        }
    }
    public void Chase() {
        //set all players to any gameobject with the tag player
        GameObject[] AllPlayers = GameObject.FindGameObjectsWithTag("Player");
        //for each gameobject in allplayers
        foreach (GameObject player in AllPlayers) {
            //add 1 to playertypes for every gameobject with the player tag
            Playertypes.Add(player.transform);
            //set chase player to get the position of the player object it sees then set the new destination to chase player
            ChasePlayer = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            Nav.SetDestination(ChasePlayer);
        }
        

    }
    public void Checklooktrue() {
        playerInSight = true;
    }
    public void Checklookfalse() {
        playerInSight = false;
    }
    // Update is called once per frame
    private void Update()
    {        
        if (!playerInSight) {
            MovementMode();
        }
        else if (playerInSight) {
            Chase();
            
            foreach (Transform players in Playertypes) {
                transform.LookAt(players);

            }
        }
    }
}
