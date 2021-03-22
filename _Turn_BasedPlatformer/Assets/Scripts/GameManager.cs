using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    

    public void Awake() {
        LoadMenu();
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void LoadMenu() {
        SceneManager.LoadScene(1);
    }

    public void LoadGame() {
        SceneManager.LoadScene(2);
    }

    public void LoadEndScreen() {
        SceneManager.LoadScene(3);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
