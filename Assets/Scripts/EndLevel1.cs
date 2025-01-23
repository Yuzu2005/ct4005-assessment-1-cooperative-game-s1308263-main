using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel1 : MonoBehaviour {

    //When player enters trigger, load new scene
    private void OnTriggerEnter(Collider enterEndTrig) {
        if (enterEndTrig.CompareTag("Player")) {
            SceneManager.LoadScene("Level2");
        }
    }
}

//Script by Jacob