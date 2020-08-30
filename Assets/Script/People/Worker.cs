using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : People
{
    public GameObject building;

    private void Start()
    {
        //ObjectPools.Intance.RenderObjectPoolsInParent(building, 50);
    }

    protected override void DetectPlayer(float detectRadius)
    {
        base.DetectPlayer(detectRadius);

        if (player != null)
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
        //find tree 
        foreach(MapItem item in mapManager.m_listMapItems)
        {
            int chance = Random.Range(0, 5);      //砍這棵樹機率
            if ((item.type == MapItemType.PINE_TREE || item.type == MapItemType.TREE_L || item.type == MapItemType.TREE_Y) && chance == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, item.go.transform.position, moveSpeed * Time.deltaTime);
                mapManager.ChangeMapItem(transform.position, MapItemType.PINE_ROOT, .2f);  //cut down tree
            }
        }

        



    }

}
