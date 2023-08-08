using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : MonoBehaviour
{  
    private float startTimeSlaveCreate;
    private float startTimeSamuraiCreate;
    private float startTimeArcherCreate;

    public Ai_Tower tower;

    public void Start()
    {
        startTimeSamuraiCreate = Time.time;

    }

    private void Update()
    {
        ShibaSamuraiCreating();
        //ShibaArcherCreating();
    }

/*    private void ShibaSlaveCreating()
    {
        if (Time.time >= startTimeSlaveCreate + 15f * tower.slaves.Count && tower.slaves.Count <= 5)
        {
            tower.CreateShibaSlave();
            startTimeSlaveCreate = Time.time;
        }
    }*/

    private void ShibaSamuraiCreating()
    {
        if (Time.time >= startTimeSamuraiCreate + 8f)
        {
            startTimeSamuraiCreate = Time.time;
            tower.CreateShibaSamurai();
        }
    }

    private void ShibaArcherCreating()
    {
        if (Time.time >= startTimeArcherCreate + Random.Range(25f, 30f))
        {
            tower.CreateShibaArcher();
            startTimeArcherCreate = Time.time;
        }
    }
}
