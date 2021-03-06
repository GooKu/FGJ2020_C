﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : People
{
    [SerializeField] private float shootRadius;

    [SerializeField] private GameObject[] wayPoints = new GameObject[10];

    [SerializeField] private float wayPointDetectDist;
    private int randomIndex = -1;

    public void Init(GameObject[] wayPoints)
    {
        this.wayPoints = wayPoints;
    }

    protected override void DetectPlayer(float detectRadius)
    {
        base.DetectPlayer(detectRadius);

        if (player != null)
        {
            if (!playerController.IsStealth)
            {
                source.clip = peopleSounds[2];
                source.Play();
                ChaseTarget(player.transform, moveSpeed);
            }
            else
            {
                Patrol();
            }
            source.clip = peopleSounds[0];
            source.Play();
            
        }
        else
        {
            Patrol();
        }
    }

    private void ChaseTarget(Transform target, float moveSpeed)
    {
        
        float dist = (transform.position - target.position).sqrMagnitude;

        if (dist <= shootRadius * shootRadius)
        {
            Shoot();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);   //移到player
        }
    }

    private void Patrol()
    {
        if(randomIndex < 0)
        {
            randomIndex = Random.Range(1, wayPoints.Length);
        }
        
        if ((transform.position - wayPoints[randomIndex].transform.position).sqrMagnitude > wayPointDetectDist * wayPointDetectDist) 
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[randomIndex].transform.position, moveSpeed * Time.deltaTime);    //移到點
        }
        else    //到點
        {
            randomIndex = -1;
        }
    }

    private void Shoot()
    {
        source.clip = peopleSounds[1];
        source.Play();
        playerController.Death();
    }
}
