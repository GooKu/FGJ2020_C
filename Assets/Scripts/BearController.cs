using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    private Vector3 moveVect = Vector3.zero;

    private GameObject c4 = null;
    private bool isGetC4 = false;

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                moveVect = Vector3.up;
                break;
            case Direction.Down:
                moveVect = Vector3.down;
                break;
            case Direction.Left:
                moveVect = Vector3.left;
                if(transform.forward == Vector3.forward)
                {
                    transform.forward = Vector3.back;
                }
                break;
            case Direction.Right:
                moveVect = Vector3.right;
                if (transform.forward == Vector3.back)
                {
                    transform.forward = Vector3.forward;
                }
                break;
        }
    }

    public void Stop()
    {
        moveVect = Vector3.zero;
    }

    public void Stealth()
    {
        //TODO:
    }

    public void Pick()
    {
        if(c4 != null)
        {
            isGetC4 = true;
            c4.transform.SetParent(transform);
        }
    }

    public void PutDown()
    {
        if (isGetC4)
        {
            c4.transform.SetParent(null);
            isGetC4 = false;
            c4 = null;
            //TODO:Add bomb component
        }
    }

    private void FixedUpdate()
    {
        transform.position += moveVect * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(c4 != null) { return; }

        if (collision.CompareTag("C4"))
        {
            c4 = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isGetC4) { return; }

        c4 = null;
    }
}
