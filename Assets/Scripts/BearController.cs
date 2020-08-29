using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    private Vector3 moveVect = Vector3.zero;

    private GameObject c4 = null;
    public bool IsGetC4 { get; private set; } = false;
    public bool IsStealth { get; private set; } = false;

    public void Move(Direction direction)
    {
        if (IsStealth) { return; }

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
        IsStealth = true;
        Stop();
    }
    public void CancelStealth()
    {
        IsStealth = false;
        //TODO: showing
    }

    public void Pick()
    {
        if(c4 == null) { return; }

        IsGetC4 = true;
        c4.transform.SetParent(transform);
    }

    public void PutDown()
    {
        if (!IsGetC4) { return; }

        c4.transform.SetParent(null);
        IsGetC4 = false;
        c4.AddComponent<Bomb>().StartUp();
        c4 = null;
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
        if (IsGetC4) { return; }

        c4 = null;
    }

    public void Death()
    {
        //TODO:
    }
}
