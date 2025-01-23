using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject mainMenu;

    private void Awake() {
        Cursor.visible = true;
    }

    //Starts game
    public void PlayGame() {
        Cursor.visible = false;
        SceneManager.LoadScene("Level1");
    }

    // Quits game
    public void QuitGame() {
        Debug.Log("QUIT SUCCESSFUL");
        Application.Quit();
    }

    //Returns to main menu
    public void ReturnToMenu() {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

    //Shows level select menu
    public void LevelSelect() {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    // shows main menu
    public void BackButton() {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

    //loads level 1
    public void Level1Select()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level1");
    }

    //loads level 2
    public void Level2Select()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level2");
    }

    //loads level 3
    public void Level3Select()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level3(BossFight)");
    }
}

// Script by Jacob
