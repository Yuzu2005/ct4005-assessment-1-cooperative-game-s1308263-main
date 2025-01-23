using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SharedLives : MonoBehaviour
{

    [SerializeField] private TMP_Text livesText;

    public int lives = 10;

    [SerializeField] private PlayerInputManager playerInputManager;

    private void Update() {
        livesText.SetText("Reinforcements: " + lives);
    }

    //removes 1 shared life
    public void RemoveLife() {
        if (lives == 0) {
            //turns off ability to respawn
            playerInputManager.enabled = false;
            if (playerInputManager.playerCount == 0) {
                //loads lose game over scene
            SceneManager.LoadScene("GameOverLose");
            }
        }
    }
}

//Script by Jacob