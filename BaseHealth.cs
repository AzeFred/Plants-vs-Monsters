using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] float baseHealth = 3f;
    float health;
    Text healthText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = baseHealth - PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<Text>();
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthText.text = health.ToString();
    }

    public void TakeHealth()
    {
        health -= 1;
        DisplayHealth();
        if (health <= 0)
        {
            FindObjectOfType<LevelController>().LoseCondition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
