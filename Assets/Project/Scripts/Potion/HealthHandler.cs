using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{

    [SerializeField] PlayerDetailsSO playerDetailsSO;
    [SerializeField] AudioDataBaseSO audioDataBaseSO;

    [SerializeField] Sprite heart;
    [SerializeField] Sprite noheart;

    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;

    [SerializeField] float maxcount = 5;

    [SerializeField] Transform potion;

    [SerializeField] float potionSpawnTimer = 5f;

    float initialPotionTimer = 0;

    float initialcountdown = 0;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        playerDetailsSO.lives = 3;
        playerDetailsSO.potionPickup = false;
    }
    private void Start()
    {
        heart1.sprite = heart;
        heart2.sprite = heart;
        heart3.sprite = heart;
    }

    private void Update()
    {
        HeartCountdown();
        SpawnManager();
        HeartSpriteEnabler();
    }

    void SpawnManager()
    {
        if (playerDetailsSO.potionPickup)
        {
            audioSource.PlayOneShot(audioDataBaseSO.potionPickUpClip);
            initialPotionTimer += Time.deltaTime;
            if (initialPotionTimer >= potionSpawnTimer)
            {
                potion.gameObject.SetActive(true);
                initialPotionTimer = 0;
            }

        }

    }
    void HeartCountdown()
    {
        initialcountdown += Time.deltaTime;

        if (initialcountdown > maxcount)
        {
            if (playerDetailsSO.lives == 3)
            {
                heart3.sprite = noheart;
                playerDetailsSO.lives--;
            }
            else if (playerDetailsSO.lives == 2)
            {
                heart2.sprite = noheart;
                playerDetailsSO.lives--;
            }
            else if (playerDetailsSO.lives == 1)
            {
                heart1.sprite = noheart;
                playerDetailsSO.lives--;
            }
            initialcountdown = 0;
        }
        if (playerDetailsSO.lives <= 0)
        {
            GetComponent<GameManager>().GameOver();
        }

    }

    private void HeartSpriteEnabler()
    {
        for (int i = 0; i < playerDetailsSO.lives; i++)
        {

            if (i == 0)
            {
                heart1.sprite = heart;

            }
            else if (i == 1)
            {
                heart2.sprite = heart;

            }
            else if (i == 2)
            {
                heart3.sprite = heart;

            }

        }
    }
}
