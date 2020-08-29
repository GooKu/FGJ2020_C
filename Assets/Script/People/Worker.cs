using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : People
{
    public GameObject building;

    private void Start()
    {
        ObjectPools.Intance.RenderObjectPoolsInParent(building, 50);
    }

    protected override void DetectPlayer(float detectRadius)
    {
        base.DetectPlayer(detectRadius);
        Debug.Log($"worker{ player }");

        if (player != null && player.gameObject.CompareTag("Player"))
        {
            RunAway();
        }
        else
        {
            Build();
        }
    }

    private void RunAway()
    {
        Vector3 runDir = (transform.position - player.transform.position).normalized;
        transform.position -= -runDir * moveSpeed * Time.deltaTime;
    }

    private void Build()
    {

    }
}
