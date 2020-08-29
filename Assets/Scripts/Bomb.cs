using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float countDownTime = 5;
    [SerializeField]
    private float bombRadius = 1;
    [SerializeField]
    private GameObject explosion = null;

    private const float explosionTime = .5f;

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


        var bear = GameObject.FindObjectOfType<BearController>();

        var dis = bear.transform.position - transform.position;

//        Debug.Log($"{bear.transform.position}, {transform.position}, {dis}, {(dis.x * dis.x + dis.y * dis.y)}");

        if((dis.x * dis.x + dis.y * dis.y) <= bombRadius * bombRadius)
        {
            bear.Death();
        }

        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }


}
