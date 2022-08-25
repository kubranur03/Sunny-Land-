using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
  
    public void Restart()
    {
        StartCoroutine(OpenGameRoutine());
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator OpenGameRoutine()
    {

        yield return new WaitForSeconds(.1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



}
