using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LastScene : MonoBehaviour
{
   


    public void LoadMenu()
    {
        SceneManager.LoadScene("MaýnMenu");

    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();

    }

}

