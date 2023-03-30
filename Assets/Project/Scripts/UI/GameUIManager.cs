using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] Button pMainMenuButton;
    [SerializeField] Button pRestartButton;
    [SerializeField] Button goMainMenuButton;
    [SerializeField] Button goQuitButton;

    [SerializeField] AudioDataBaseSO audioDataBaseSO;

    AudioSource audioSource;


    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        pMainMenuButton.onClick.AddListener(LoadMainMenu);
        pRestartButton.onClick.AddListener(RestartLevel);
        goMainMenuButton.onClick.AddListener(LoadMainMenu);
        goQuitButton.onClick.AddListener(QuitGame);
    }

    void LoadMainMenu()
    {
        audioSource.clip = audioDataBaseSO.onButtonClickedClip;
        audioSource.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    void RestartLevel()
    {
        audioSource.clip = audioDataBaseSO.onButtonClickedClip;
        audioSource.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void QuitGame()
    {
        audioSource.clip = audioDataBaseSO.onButtonClickedClip;
        audioSource.Play();
        Application.Quit();
    }
}
