using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    PlayerController player;
    GameManager gameManager;
    [SerializeField] float enemyHeight = 3f;
    [SerializeField] float maximumDistance = 5f;
    
    

    RaycastHit hit;


    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
        
    }


    private void Update()
    {
       
        if (Physics.Raycast(transform.position + Vector3.up * enemyHeight, transform.forward, out hit, maximumDistance))
        {
            if (hit.transform == player.gameObject.transform)
            {
                gameManager.GameOver();
            }
            
        }
    }
}
