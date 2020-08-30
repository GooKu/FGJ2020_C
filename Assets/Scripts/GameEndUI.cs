using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [SerializeField]
    private Text forestPresentTxt = null;
    [SerializeField]
    private Text killPeopleTxt = null;
    [SerializeField]
    private Text bombExplosionTxt = null;
    [SerializeField]
    private GameMapManager gameMapManager = null;

    private int peopleDieCount;
    private int bombExplosionCount;

    public void Init()
    {
        peopleDieCount = 0;
        bombExplosionCount = 0;
        EventManager.AddListen(GameEvents.PeopleDie, CountPeopleDie);
        EventManager.AddListen(GameEvents.BombExplsion, CountBombExplosion);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListen(GameEvents.PeopleDie, CountPeopleDie);
        EventManager.RemoveListen(GameEvents.BombExplsion, CountBombExplosion);
    }

    public void Show()
    {
        float forestPresent = gameMapManager.mapResultEnd.treeCount / (float)gameMapManager.mapResultStart.treeCount;

        forestPresentTxt.text = forestPresent.ToString("#0.00%");
        killPeopleTxt.text = peopleDieCount.ToString();
        bombExplosionTxt.text = bombExplosionCount.ToString();
        gameObject.SetActive(true);
    }

    private void CountPeopleDie(object[] data)
    {
        peopleDieCount++;
    }

    private void CountBombExplosion(object[] data)
    {
        bombExplosionCount++;
    }
}
