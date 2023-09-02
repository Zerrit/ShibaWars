using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaArcher_Projectile : MonoBehaviour
{
    //private Animator anim;
    private SpriteRenderer sr;

    public Transform enemy;
    public Vector2 start;
    private Vector2 p1 ,p2, p3;
    private float projectileHeght;

    public float arrowSpeed = 1f;


    [Range(0, 1)]
    public float t;
    private bool isMovement = false;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    private void FixedUpdate()
    {
        if (isMovement)
        {
            BezieMovement();
        }
    }

    public void Fire()
    {
        isMovement = true;
        sr.enabled = true;
    }

    private void BezieMovement()
    {
        if(t >= 1)
        {
            isMovement = false;
            sr.enabled = false;
            t = 0;
        }
        else
        {
            t += 0.045f * arrowSpeed;
        }

        projectileHeght = 60 / Mathf.Abs(enemy.position.x - start.x);
        p3 = enemy.position;
        p1 = Vector2.Lerp(start, p3, 0.4f);
        p2 = Vector2.Lerp(start, p3, 0.8f);
        p1.y = Mathf.Clamp(projectileHeght, 5, 15);
        p2.y = Mathf.Clamp(projectileHeght, 5, 15);
        transform.position = GetPont(start, p1, p2, p3, t);
        transform.rotation = Quaternion.FromToRotation(Vector3.right, GetDerivative(start, p1, p2, p3, t));
    }

    private Vector2 GetPont(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        Vector2 p01 = Vector2.Lerp(p0, p1, t);
        Vector2 p12 = Vector2.Lerp(p1, p2, t);
        Vector2 p23 = Vector2.Lerp(p2, p3, t);

        Vector2 p012 = Vector2.Lerp(p01, p12, t);
        Vector2 p123 = Vector2.Lerp(p12, p23, t);

        Vector2 p0123 = Vector2.Lerp(p012, p123, t);

        return p0123;
    }

    private Vector2 GetDerivative(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }
}
