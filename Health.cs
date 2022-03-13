using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public float ReturnHealth()
    {
        return health;
    }
    
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            TriggerVFX();          
        }
    }

    public void TriggerVFX()
    {
        Instantiate(deathVFX, transform.position, transform.rotation);
    }
}
