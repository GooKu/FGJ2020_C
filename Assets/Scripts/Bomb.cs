using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float countDownTime = 5;
    private const float explosionTime = 1;

    public void StartUp()
    {
        StartCoroutine(countDown());
    }

    private IEnumerator countDown()
    {
        do
        {
            yield return null;
            countDownTime -= Time.deltaTime;
            //TODO: call UI
        } while (countDownTime > 0);

        //TODO:explosion
        yield return explosionTime;

        Destroy(gameObject);
    }


}
