using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(0, 3)] float walkSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawn();
    }

    private void OnDestroy()
    {
        LevelController level = FindObjectOfType<LevelController>();
        if (level != null)
        {
            level.AttackerKilled();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * SetMoveSpeed(walkSpeed) * Time.deltaTime);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
            SetMoveSpeed(1f);
        }
    }

    public float SetMoveSpeed(float speed)
    {
        walkSpeed = speed;
        return walkSpeed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget (float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
