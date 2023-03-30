using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickup : MonoBehaviour
{
    [SerializeField] PlayerDetailsSO playerDetailsSO;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerDetailsSO.lives < 3)
        {
            playerDetailsSO.lives++;
            playerDetailsSO.potionPickup = true;
            gameObject.SetActive(false);
        }
    }
}
