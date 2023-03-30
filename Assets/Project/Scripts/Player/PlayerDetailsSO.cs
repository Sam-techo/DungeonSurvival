using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerDetailsSO : ScriptableObject
{
    public string playerName;
    public float score;
    public int lives;
    public bool potionPickup;
}
