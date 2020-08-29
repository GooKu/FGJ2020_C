using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    private Vector3 moveVect = Vector3.zero;

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
                break;
            case Direction.Right:
                moveVect = Vector3.right;
                break;
        }
    }

    public void Stop()
    {
        moveVect = Vector3.zero;
    }

    public void Stealth()
    {

    }

    public void Pick()
    {

    }

    public void PutDown()
    {

    }

    private void FixedUpdate()
    {
        transform.position += moveVect * moveSpeed * Time.fixedDeltaTime;
    }
}
