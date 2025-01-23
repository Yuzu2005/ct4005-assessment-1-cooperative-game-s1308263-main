using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class TankBoss : MonoBehaviour
{
    //[SerializeField] private GameObject Tank;
    //private Vector3 WalkTo;
    //private bool PointerSet;
    //bool playerInSight;

    //public NavMeshAgent Nav;
    //public LayerMask floorlayer;
    //public float WalkingRange;
    //public float BulletDeath = 0.5f;
    //public float Raydistance = 70;
    //private float timer;
    ////Reference for bullet prefab
    //[SerializeField] private GameObject Tankbullet;
    ////Reference for EnemyProjectile prefab
    //[SerializeField] private GameObject EnemyProjectile;
    ////creates a list which gets the transform
    //List<Transform> Playertypes = new List<Transform>();

    //public GameObject enemies;
    ////Animator animator;

    //private void Awake() {
    //    Nav = GetComponent<NavMeshAgent>();

    //}
    //private void Start() {
    //    //adds a new gameobjects position to the playertypes with the tag player
    //    GameObject[] AllPlayers = GameObject.FindGameObjectsWithTag("Player");
    //    foreach (GameObject player in AllPlayers) {
    //        //adds 1 to playertypes for every gameobject with the player tag
    //        Playertypes.Add(player.transform);

    //    }
    //}
    //public void MovementMode() {
    //    if (PointerSet) {
    //        Nav.SetDestination(WalkTo);


    //        //anims.Play("Crouched Walking");
    //    }
    //    if (!PointerSet) {
    //        SearchMode();
    //    }
    //    Vector3 WalkingDistance = transform.position - WalkTo;
    //    if (WalkingDistance.magnitude < 1f) {
    //        PointerSet = false;
    //    }
    //}
    //private void SearchMode() {
    //    //gets a random position on the x and y axis
    //    float AxisX = Random.Range(-WalkingRange, WalkingRange);
    //    float AxisZ = Random.Range(-WalkingRange, WalkingRange);
    //    WalkTo = new Vector3(transform.position.x + AxisX, transform.position.y, transform.position.z + AxisZ);
    //    //cast raycast to the new targeted location
    //    if (Physics.Raycast(WalkTo, -transform.up, 2f, floorlayer)) {
    //        PointerSet = true;
    //    }
    //}
    //private IEnumerator Shoot() {
    //    timer += Time.deltaTime;
    //    if (timer >= 1.5) {
    //        //after 1.5 secs it will create a clone bullet from the bullet prefab
    //        //shooting = true;
    //        var CreateBullet = Instantiate(Tankbullet, EnemyProjectile.transform.position, EnemyProjectile.transform.rotation);
    //        yield return timer = 0;
    //        Destroy(CreateBullet, BulletDeath);
    //        StartCoroutine("Shoot", timer);
    //    }
    //}
    //public void Checklooktrue() {
    //    playerInSight = true;
    //}
    //public void Checklookfalse() {
    //    playerInSight = false;
       
    //}

    //private void Update() {
    //    if (!playerInSight) {
    //        MovementMode();
    //        StopCoroutine("Shoot");
    //        //GameObject[] TankHead = GameObject.FindGameObjectsWithTag("TankHead");
    //        //foreach (GameObject HeadPiece in TankHead) {
    //        //    //adds 1 to playertypes for every gameobject with the player tag
    //        //    Playertypes.Add(HeadPiece.transform);
    //        //    transform.LookAt(HeadPiece.transform);
    //        //}
    //        //Tank.GetComponent<lookaround>().LookAbout();


    //    }
    //    if (playerInSight) {
    //        StartCoroutine("Shoot", timer);
    //        enemies.GetComponent<Animations>().TankBoss();
    //        //for each player in playertypes get its position and face its direction
    //        foreach (Transform players in Playertypes) {
    //            transform.LookAt(players);
    //        }
    //    }
    //}
}
