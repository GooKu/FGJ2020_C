using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameBGMType
{
    TITLE,
    GAME_PLAY,
    GAME_END,
    GAME_OVER,
    MAX
}

public class GameMusicManager : MonoBehaviour
{
    public GameObject go_bgm1 = null;
    public GameObject go_bgm2 = null;
    public GameObject go_bgm3 = null;
    public GameObject go_bgm4 = null;

    private int playingIndex = 0;
    private List<AudioSource> as_bgms = new List<AudioSource>();
    
    private void Play(object[] callBack)
    {
        PlayBGM((int)callBack[0]);
    }

    private void PlayBGM(int idx)
    {
        if (playingIndex > 0) {
            // stop playing BGM
            var lastBGM = as_bgms[playingIndex];
            if (lastBGM.isPlaying) {
                lastBGM.Stop();
            }
        }
        playingIndex = idx;

        // play selected BGM
        var thisBGM = as_bgms[idx];
        thisBGM.Play();
    }

    void Start()
    {
        as_bgms.Add(go_bgm1.GetComponent<AudioSource>());
        as_bgms.Add(go_bgm2.GetComponent<AudioSource>());
        as_bgms.Add(go_bgm3.GetComponent<AudioSource>());
        as_bgms.Add(go_bgm4.GetComponent<AudioSource>());

        EventManager.AddListen(GameEvents.PlayBGM, Play);
        EventManager.AddListen(GameEvents.GameStart, PlayGamePlayMusic);
        EventManager.AddListen(GameEvents.GameEnd, PlayGameEndMusic);
        EventManager.AddListen(GameEvents.GameOver, PlayGameOverMusic);

        // dufaut bgm
        PlayBGM((int)GameBGMType.GAME_PLAY);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListen(GameEvents.PlayBGM, Play);
        EventManager.RemoveListen(GameEvents.GameStart, PlayGamePlayMusic);
        EventManager.RemoveListen(GameEvents.GameEnd, PlayGameEndMusic);
        EventManager.RemoveListen(GameEvents.GameOver, PlayGameOverMusic);
    }

    private void PlayGamePlayMusic(object[] callBack)
    {
        PlayBGM((int)GameBGMType.GAME_PLAY);
    }

    private void PlayGameEndMusic(object[] callBack)
    {
        PlayBGM((int)GameBGMType.GAME_END);
    }

    private void PlayGameOverMusic(object[] callBack)
    {
        PlayBGM((int)GameBGMType.GAME_OVER);
    }

    // void Update()
    // {
        
    // }
}
