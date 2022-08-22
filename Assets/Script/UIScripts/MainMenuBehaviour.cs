using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuBehaviour : MonoBehaviour
{

    public string sceneName;

    [SerializeField] private GameObject imgObject;
    [SerializeField] private GameObject startButtonObject, exitButtonObject;


    [SerializeField] private GameObject fadeScreenObject;


    private void Start()
    {
        StartCoroutine(OpenInOrderRoutine());
    }

    IEnumerator OpenInOrderRoutine()
    {
        yield return new WaitForSeconds(.4f);

        imgObject.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

        yield return new WaitForSeconds(.4f);

        startButtonObject.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        startButtonObject.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.4f);

        exitButtonObject.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        exitButtonObject.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);

    }

    public void StartGame()
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
        fadeScreenObject.GetComponent<CanvasGroup>().DOFade(1, 1f);

        yield return new WaitForSeconds(.1f);

        SceneManager.LoadScene(sceneName);

    }
}
