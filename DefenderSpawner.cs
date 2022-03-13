using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToDefender(SnapToGrid(GetSquareClicked()));    
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptToDefender(Vector2 gridPosition)
    {
        var sunDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetSunCost();
        // if we have enough suns to produce a defender
        if(sunDisplay.HaveEnoughSuns(defenderCost))
        {
            SpawnDefender(SnapToGrid(gridPosition));
            sunDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }

    private Vector2 SnapToGrid(Vector2 worldPosition)
    {
        float newX = Mathf.RoundToInt(worldPosition.x);
        float newY = Mathf.RoundToInt(worldPosition.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPosition)
    {
        Defender newDefender = Instantiate(defender, worldPosition, transform.rotation) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
