using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMnager : MonoBehaviour
{
    [SerializeField]
    private GameObject workerSample = null;
    [SerializeField]
    private GameObject hunterSample = null;

    private void Start()
    {
        GameObject.Instantiate(workerSample, GetBirthPoint(), Quaternion.identity);

        var wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

        GameObject.Instantiate(hunterSample, GetBirthPoint(), Quaternion.identity)
            .GetComponent<Hunter>().Init(wayPoints);
    }

    private Vector3 GetBirthPoint()
    {
        Vector3 result = Vector3.zero;

        var randResult = Random.Range(0, 2);

        if(randResult > 0)
        {
            result.x = GameBound.MaxX + Random.Range(.2f, 2f);
        }
        else
        {
            result.x = GameBound.MinX - Random.Range(.2f, 2f);
        }

        randResult = Random.Range(0, 2);

        if (randResult > 0)
        {
            result.y = GameBound.MaxY + Random.Range(.2f, 2f);
        }
        else
        {
            result.y = GameBound.MaxY - Random.Range(.2f, 2f);
        }

        return result;
    }
}
