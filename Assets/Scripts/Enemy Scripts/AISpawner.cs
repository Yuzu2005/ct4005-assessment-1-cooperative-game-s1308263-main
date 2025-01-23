using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using TMPro;

public class AISpawner : MonoBehaviour
{
    public List<Transform> enemyList;

    [SerializeField] private GameObject endTrigger;
    [SerializeField] private TMP_Text enemiesText;
    [SerializeField] private Transform enSpawnPos1, enSpawnPos2, enSpawnPos3, enSpawnPos4, enSpawnPos5, enSpawnPos6;

    [SerializeField] private float SpawnTime;
    public int maxEnemies = 10;
    private bool justWokeUp;
    private bool isMaxEnemys;
    //Reference for EnemyShooter prefab
    [SerializeField] private GameObject EnemyShooter;
    [SerializeField] private GameObject EnemyFighter;
    //Reference for EnemySpawner prefab
    [SerializeField] private GameObject EnemySpawner;

    private void Awake()
    {
        isMaxEnemys = false;
        justWokeUp = true;
        StartCoroutine("SpawnDelay");
    }

    private void Update() {
        if (enemyList.Count > 0) {
            enemiesText.SetText("Enemies Left: " + enemyList.Count);
        }
    }

    public IEnumerator SpawnDelay()
    {
        //SpawnTime += Time.deltaTime;
        if (enemyList.Count != maxEnemies)
        {
            if (isMaxEnemys == false)  //SpawnTime >= 1 &&
            {
                //get a random range
                int EnemyVersion = Random.Range(1, 3);
                if (EnemyVersion == 1)
                {
                    //canSpawn = false;
                    //creates a clone of the enemy shooter and sets its spawn position and rotation to the enemy spawner
                    var EnemyType1 = Instantiate(EnemyShooter, EnemySpawner.transform.position, EnemySpawner.transform.rotation);
                }
                else if (EnemyVersion == 2)
                {
                    //canSpawn = false;
                    //creates a clone of the enemy fighter and sets its spawn position and rotation to the enemy spawner
                    var EnemyType2 = Instantiate(EnemyFighter, EnemySpawner.transform.position, EnemySpawner.transform.rotation);
                }
                //var EnemyType2 = Instantiate(EnemyFighter, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
                //if enemys eqaul to or are larger than maxEnemies set max enemys to true
                if (enemyList.Count == maxEnemies)
                {
                    isMaxEnemys = true;
                }
                //Added by Jacob
                justWokeUp = false;
                int spawnPos = Random.Range(0, 5);
                switch (spawnPos)
                {
                    case 0:
                    gameObject.transform.position = enSpawnPos1.transform.position;
                        break;
                    case 1:
                    gameObject.transform.position = enSpawnPos2.transform.position;
                        break;
                    case 2:
                    gameObject.transform.position = enSpawnPos3.transform.position;
                        break;
                    case 3:
                    gameObject.transform.position = enSpawnPos4.transform.position;
                        break;
                    case 4:
                    gameObject.transform.position = enSpawnPos5.transform.position;
                        break;
                    case 5:
                    gameObject.transform.position = enSpawnPos6.transform.position;
                        break;

                }
            }
            CheckEnd();
        }
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine("SpawnDelay");
    }

    //Added by Jacob
    private void CheckEnd() {
        if (justWokeUp == false && enemyList.Count == 0) {
            Debug.Log("spawner stopped");
            endTrigger.SetActive(true);
            enemiesText.SetText("Get to the exit!");
        }
    }

    //Added by Jacob
    public void AddEnemy(Transform en){
        enemyList.Add(en);
    }

    public void RemoveEnemy(Transform en) {
        enemyList.Remove(en);

    }
}
