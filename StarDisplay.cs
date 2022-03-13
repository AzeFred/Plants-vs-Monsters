using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int suns = 300;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        DisplayStars();
    }

    private void DisplayStars()
    {
        starText.text = suns.ToString();
    }

    public bool HaveEnoughSuns(int amount)
    {
        return suns >= amount;
    }

    public void AddStars(int amount)
    {
        suns += amount;
        DisplayStars();
    }

    public void SpendStars(int amount)
    {
        if (suns >= amount)
        {
            suns -= amount;
            DisplayStars();
        }
    }
}
