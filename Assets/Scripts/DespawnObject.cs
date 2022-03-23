using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObject : MonoBehaviour
{
    private float startTime;
    public int timeToDespawn;

    public Collider2D col { get; private set; }

    void Start()
    {
        startTime = Time.time;
        col = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Time.time - startTime >= timeToDespawn)
        {
            col.enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
