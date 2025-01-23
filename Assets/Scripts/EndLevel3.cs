using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel3 : MonoBehaviour {

    //When a player enters trigger and boss health = 0, load new scene
    private void OnTriggerEnter(Collider enterEndTrig) {
        TryGetComponent<BossHealth>(out BossHealth comp);
        if (enterEndTrig.CompareTag("Player") && comp.Health == 0) {
            SceneManager.LoadScene("GameOverWin");
        }
    }
}

//Script by Jacob