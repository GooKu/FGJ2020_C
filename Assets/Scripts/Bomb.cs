using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float countDownTime = 5;
    [SerializeField]
    private float bombRadius = 1;
    private const float explosionTime = 1;

    private void Awake()
    {

    }

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

        var bear = GameObject.FindObjectOfType<BearController>();

        var dis = bear.transform.position - transform.position;

//        Debug.Log($"{bear.transform.position}, {transform.position}, {dis}, {(dis.x * dis.x + dis.y * dis.y)}");

        if((dis.x * dis.x + dis.y * dis.y) <= bombRadius * bombRadius)
        {
            bear.Death();
        }

        Destroy(gameObject);
    }


}
