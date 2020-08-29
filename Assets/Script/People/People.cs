using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class People : MonoBehaviour
{
    [SerializeField] protected LayerMask playerLayer;
    protected Collider2D player;

    [SerializeField] protected float detectRadius;
    [SerializeField] protected float moveSpeed;

    public void Update()
    {
        DetectPlayer(detectRadius);
    }

    protected virtual void DetectPlayer(float detectRadius)
    {
        player = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);

        
    }


}
