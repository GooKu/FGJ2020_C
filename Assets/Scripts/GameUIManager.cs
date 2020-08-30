using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI = null;
    [SerializeField]
    private GameEndUI gameEndUI = null;

    private void Start()
    {
        EventManager.AddListen(GameEvents.GameOver, GameOverHandle);
        EventManager.AddListen(GameEvents.GameEnd, GameEndHandle);
        gameEndUI.Init();
    }

    private void OnDestroy()
    {
        EventManager.RemoveListen(GameEvents.GameOver, GameOverHandle);
        EventManager.RemoveListen(GameEvents.GameEnd, GameEndHandle);
    }

    private void GameOverHandle(object[] callBack)
    {
        gameOverUI.SetActive(true);
    }

    private void GameEndHandle(object[] callBack)
    {
        gameEndUI.Show();
    }
}
