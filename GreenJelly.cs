using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenJelly : MonoBehaviour
{
    Attacker attacker;
    float damage = 25f;
    float health;
    // Start is called before the first frame update
    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
            attacker.SetMoveSpeed(0f);
            attacker.StrikeCurrentTarget(damage);
        }
    }
}
