using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text timer;
    [SerializeField] private int totalGameTime;
    private float time;

    private void Start()
    {
        EventManager.AddListen(GameEvents.GameOver, Stop);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListen(GameEvents.GameOver, Stop);
    }

    private void Update()
    {
        time += Time.deltaTime;
        timer.text = $"Time: {totalGameTime - (int)time}";

        if(time >= totalGameTime)
        {
            EventManager.SendEvent(GameEvents.GameEnd);
            enabled = false;
        }
    }

    private void Stop(object[] callBack)
    {
        enabled = false;
    }
}
