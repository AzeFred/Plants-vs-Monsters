using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelButtonCost();
    }

    private void LabelButtonCost()
    {
        Text costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetSunCost().ToString();
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(53, 51, 51, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
