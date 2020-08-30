using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bar_bg = null;
    public GameObject bar = null;

    private const float countDownTimeMax = 5.0f;

    [SerializeField]
    private float countDownTime = countDownTimeMax;
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
        EnableBar();
        StartCoroutine(countDown());
    }

    private IEnumerator countDown()
    {
        do
        {
            yield return null;
            countDownTime -= Time.deltaTime;
            //TODO: call UI
            SetBar(countDownTime / countDownTimeMax);
        } while (countDownTime > 0);

        var checkRadiusSpr = bombRadius * bombRadius;

        var bear = GameObject.FindObjectOfType<BearController>();

        var dis = bear.transform.position - transform.position;

//        Debug.Log($"{bear.transform.position}, {transform.position}, {dis}, {(dis.x * dis.x + dis.y * dis.y)}");

        if((dis.x * dis.x + dis.y * dis.y) <= checkRadiusSpr)
        {
            bear.Death();
        }

        var humans = GameObject.FindObjectsOfType<People>();

        foreach(var human in humans)
        {
            dis = human.transform.position - transform.position;

            if ((dis.x * dis.x + dis.y * dis.y) <= checkRadiusSpr)
            {
                human.Die();
            }
        }

        GameObject.FindObjectOfType<GameMapManager>().DestoryMapItem(transform.position, checkRadiusSpr);

        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
        EventManager.SendEvent(GameEvents.BombExplsion);

        Destroy(gameObject);
    }

    private void EnableBar()
    {
        this.bar_bg.SetActive(true);
        this.bar.SetActive(true);
    }

    // 0.0f ~ 1.0f
    private void SetBar(float value)
    {
        this.bar.transform.localScale = new Vector3(value, this.bar.transform.localScale.y, this.bar.transform.localScale.z);
    }

}
