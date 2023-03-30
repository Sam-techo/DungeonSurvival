using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] AudioDataBaseSO audioDataBaseSO;

    [SerializeField] Button playButton;
    [SerializeField] Button exitButton;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
    }
    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
           
    }

    void OnPlayButtonClicked()
    {
        audioSource.clip = audioDataBaseSO.onButtonClickedClip;
        audioSource.Play();
        SceneManager.LoadScene(1);
    }

    void OnExitButtonClicked()
    {
        audioSource.clip = audioDataBaseSO.onButtonClickedClip;
        audioSource.Play();
        Application.Quit();
    }


   
}
