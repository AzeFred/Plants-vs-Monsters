using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool timerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitSeconds = 3f;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawn()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && timerFinished)
        {
            StartCoroutine(WinCondition());
        }
    }

    IEnumerator WinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitSeconds);
        FindObjectOfType<Level>().LoadNextScene();
    }

    public void LoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }


    public void LevelTimerFinished()
    {
        timerFinished = true;
        StopSpawners();
    }

    public void StopSpawners()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.StopSpawn();
        }
    }

}
