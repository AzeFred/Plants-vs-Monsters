using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] Attacker[] enemy;

    // Start is called before the first frame update
    IEnumerator Start()
    {   
       while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(1, 10));
            SpawnEnemies();
        }
    }

    public void StopSpawn()
    {
        spawn = false;
    }

    private void SpawnEnemies()
    {
        Attacker newAttacker = Instantiate(enemy[Random.Range(0,enemy.Length)], transform.position, Quaternion.Euler(0f, -180f, 0f)) as Attacker;
        //newAttacker.transform.parent = transform;
        newAttacker.transform.SetParent(transform,true);
    }
}
