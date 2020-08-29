using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveStream : MonoBehaviour
{
    [SerializeField] private Text viewsUI;

    private int views;
    [SerializeField] private int viewsGrowSpeed;
    [SerializeField] private GameObject[] emojis;

    private void Update()
    {
        views += viewsGrowSpeed;
        viewsUI.text = views.ToString();

        
    }

    private void FlowEmoji()
    {

    }
}
