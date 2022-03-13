using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("Our Level Timer in Seconds")]
    [SerializeField] float levelTimer = 10f;
    bool triggered;

    // Update is called once per frame
    void Update()
    {
        if (triggered) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggered = true;
        }
    }
}
