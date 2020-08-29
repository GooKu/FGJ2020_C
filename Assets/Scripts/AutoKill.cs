using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    [SerializeField]
    private float existTime = .5f;

    private void Update()
    {
        existTime -= Time.deltaTime;

        if(existTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
