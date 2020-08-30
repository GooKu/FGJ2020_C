﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class People : MonoBehaviour
{
    [SerializeField] protected LayerMask playerLayer;
    protected Collider2D player;
    protected BearController playerController;
    protected GameMapManager mapManager;
    [SerializeField] protected Sprite deathSprite;

    [SerializeField] protected float detectRadius;
    [SerializeField] protected float moveSpeed;

    private void Awake()
    {
        playerController = (BearController)FindObjectOfType(typeof(BearController));
        mapManager = (GameMapManager)FindObjectOfType(typeof(GameMapManager));
    }

    public void Update()
    {
        DetectPlayer(detectRadius);
    }

    protected virtual void DetectPlayer(float detectRadius)
    {
        player = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);

        if (playerController.IsStealth)
        {
            return;
        }
    }

    public virtual void Die()
    {
        EventManager.SendEvent(GameEvents.PeopleDie);
        gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GetComponent<SpriteRenderer>().color;
        Gizmos.DrawWireSphere(gameObject.transform.position, detectRadius);
    }
}
