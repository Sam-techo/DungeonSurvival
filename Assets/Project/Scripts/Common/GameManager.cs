using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerDetailsSO playerDetailsSO;

    [SerializeField] GameInput gameInput;
    [SerializeField] Transform player;

    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] TextMeshProUGUI score;

    AudioSource audioSource;
    
    private bool isPaused = false;


    private void Awake()
    {
        
        playerDetailsSO.score= 0;
        
    }

    private void Start()
    {
        gameInput.OnPause += PauseGame;

        
    }

    private void Update()
    {
        ScoreHandler();
    }

    

    private void PauseGame(object sender, EventArgs e)
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseCanvas.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.gameObject.SetActive(false);
        }
    }


    private void ScoreHandler()
    {
        playerDetailsSO.score += Time.deltaTime;

        score.text = "Score: " + (int)playerDetailsSO.score;
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        Time.timeScale = 0;
        gameOverCanvas.gameObject.SetActive(true);

    }
}
