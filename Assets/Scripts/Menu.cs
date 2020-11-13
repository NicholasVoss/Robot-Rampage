using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //start game when player clicks start button
    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }

    //quits game when player clicks quit button
    public void Quit()
    {
        Application.Quit();
    }
}
