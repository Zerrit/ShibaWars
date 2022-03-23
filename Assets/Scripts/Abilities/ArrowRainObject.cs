using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRainObject : MonoBehaviour
{
    public LayerMask enemyLayer;
    public int damage; 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if((enemyLayer | 1 << collision.gameObject.layer) == enemyLayer)
        {
            collision.gameObject.GetComponent<Health>().GetDamage(25 * Time.deltaTime);
        }
        
    }
}
