using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int sunCost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetSunCost()
    {
        return sunCost;
    }
}
