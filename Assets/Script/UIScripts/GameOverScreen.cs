using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public string sceneName;

    PlayerHealtBehaviour playerHealtBehaviour;

    private void Awake()
    {
        playerHealtBehaviour = Object.FindObjectOfType<PlayerHealtBehaviour>();
    }

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

        SceneManager.LoadScene(sceneName);

    }



}
