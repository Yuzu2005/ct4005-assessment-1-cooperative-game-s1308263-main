using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel2 : MonoBehaviour {

    //When a player enters trigger, load new scene
    private void OnTriggerEnter(Collider enterEndTrig) {
        if (enterEndTrig.CompareTag("Player")) {
            SceneManager.LoadScene("Level3(BossFight)");
        }
    }
}

//Script by Jacob