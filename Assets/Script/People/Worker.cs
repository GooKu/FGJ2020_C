using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : People
{
    private enum WorkerState
    {
        Idle,
        LockTree,
        CutingDownTree,
        Building,
        Running
    }

    private WorkerState curState;

    private MapItem item;
    [SerializeField] private GameObject C4;

    private void Start()
    {
        curState = WorkerState.Idle;
    }

    protected override void DetectPlayer(float detectRadius)
    {
        base.DetectPlayer(detectRadius);

        if (playerController.IsStealth)
        {
            return;
        }

        if (player != null)
        {
            RunAway();
            if (curState == WorkerState.Running)
                DropC4();
        }
        else
        {
            Build();
        }
    }

    private void RunAway()
    {
        curState = WorkerState.Running;
        source.Play();
        Vector3 runDir = (transform.position - player.transform.position).normalized;
        transform.position -= -runDir * moveSpeed * Time.deltaTime;
    }

    private void DropC4()
    {
        int ran = UnityEngine.Random.Range(0, 200);
        if (ran == 0)
            Instantiate(C4, transform.position, Quaternion.identity);
    }

    private void Build()
    {
        if (curState == WorkerState.Idle || curState == WorkerState.Running)
            curState = WorkerState.LockTree;
        
        if(curState == WorkerState.LockTree)
        {
            int chance = UnityEngine.Random.Range(0, mapManager.m_listMapItems.Count);      //隨機樹
            item = mapManager.m_listMapItems[chance];
            curState = WorkerState.CutingDownTree;
        }

        if ((item.type == MapItemType.PINE_TREE || item.type == MapItemType.TREE_L || item.type == MapItemType.TREE_Y)
             && curState == WorkerState.CutingDownTree)
        {
            transform.position = Vector2.MoveTowards(transform.position, item.go.transform.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, item.go.transform.position) < .2f)
            {
                StartCoroutine(CutDownTree(item));
            }
        }

        //build
        if(curState == WorkerState.Building)
        {
            if(item.type == MapItemType.PINE_ROOT)
                mapManager.ChangeMapItem(transform.position, MapItemType.HOUSE_HALF, .01f);
            else if(item.type == MapItemType.HOUSE_HALF)
                StartCoroutine(BuildHouse());
        }
    }

     private IEnumerator CutDownTree(MapItem item)
     {
        yield return new WaitForSeconds(1f);
        if (item.type != MapItemType.PINE_ROOT && item.type != MapItemType.HOUSE_HALF)
            mapManager.ChangeMapItem(transform.position, MapItemType.PINE_ROOT, .2f);  //cut down tree
        curState = WorkerState.Building;
        yield break;
    }

    private IEnumerator BuildHouse()
    {
        yield return new WaitForSeconds(1f);
        mapManager.ChangeMapItem(transform.position, MapItemType.HOUSE_COMP, .01f);
        curState = WorkerState.Idle;
        yield break;
    }
}
