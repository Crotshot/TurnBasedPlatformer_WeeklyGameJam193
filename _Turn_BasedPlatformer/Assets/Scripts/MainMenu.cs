using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameManager gM;

    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    public void StartGameButton() {
        gM.LoadGame();
    }

    public void QuitGameButton() {
        gM.QuitGame();
    }

    public void MainMenuButton() {
        gM.LoadMenu();
    }
}
