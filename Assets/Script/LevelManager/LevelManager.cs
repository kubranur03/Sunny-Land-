using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    PlayerController playerController;
    UIBehaviour uIBehaviour;

    public string sceneName;
    
    private void Awake()
    {
        instance = this;
        playerController = Object.FindObjectOfType<PlayerController>();
        uIBehaviour = Object.FindObjectOfType<UIBehaviour>();
    }

    public int theNumberOfJewelsCollected;

   public void FinishTheScene()
    {
        StartCoroutine(FinishTheSceneRoutine());

    }
    
    IEnumerator FinishTheSceneRoutine()
    {
        yield return new WaitForSeconds(.1f);
        playerController.shouldMove = false;

        yield return new WaitForSeconds(.1f);
        uIBehaviour.OpenFadeScreen();

        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene(sceneName);
    }


}
