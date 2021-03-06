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
    [SerializeField] protected AudioSource source;
    [SerializeField] protected AudioClip[] peopleSounds; 

    [SerializeField] protected float detectRadius;
    [SerializeField] protected float moveSpeed;

    private void Awake()
    {
        playerController = (BearController)FindObjectOfType(typeof(BearController));
        mapManager = (GameMapManager)FindObjectOfType(typeof(GameMapManager));
        source = GetComponent<AudioSource>();

        EventManager.AddListen(GameEvents.GameOver, PeopleStop);
        EventManager.AddListen(GameEvents.GameEnd, PeopleStop);
    }

    public void Update()
    {
        if(gameObject != null)
            DetectPlayer(detectRadius);
    }

    protected virtual void DetectPlayer(float detectRadius)
    {
        player = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);
    }

    protected virtual void PeopleStop(object[] callback)
    {
        enabled = false;
    }

    public virtual void Die()
    {
        EventManager.SendEvent(GameEvents.PeopleDie);
        gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
        enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GetComponent<SpriteRenderer>().color;
        Gizmos.DrawWireSphere(gameObject.transform.position, detectRadius);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListen(GameEvents.GameOver, PeopleStop);
        EventManager.RemoveListen(GameEvents.GameEnd, PeopleStop);
    }
}
