using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;
    EnemySpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (isAttackerInLane())
        { animator.SetBool("isAttacking", true); }
        else { animator.SetBool("isAttacking", false); }
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= 0.5f;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool isAttackerInLane()
    {
        if( myLaneSpawner.transform.childCount > 0)
            { return true; }
        else
            { return false; }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
