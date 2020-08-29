using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text timer;
    [SerializeField] private int totalGameTime;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        timer.text = $"Time: {totalGameTime - (int)time}";
    }
}
