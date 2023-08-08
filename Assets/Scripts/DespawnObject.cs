using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObject : MonoBehaviour
{
    private float startTime;
    public int timeToDespawn;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(Time.time - startTime >= timeToDespawn)
        {
            Destroy(gameObject, 2f);
        }
    }
}
