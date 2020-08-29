using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private BearController bear;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            bear.Move(Direction.Left);
        }else if (Input.GetKey(KeyCode.D))
        {
            bear.Move(Direction.Right);
        }else if (Input.GetKey(KeyCode.W))
        {
            bear.Move(Direction.Up);
        }else if (Input.GetKey(KeyCode.S))
        {
            bear.Move(Direction.Down);
        }
        else
        {
            bear.Stop();
        }
    }

    //trigger by button
    public void OnPickClick()
    {
        if (bear.IsStealth) { return; }

        if (bear.IsGetC4)
        {
            bear.PutDown();
        }
        else
        {
            bear.Pick();
        }
    }

    //trigger by button
    public void OnStealthClick()
    {
        if (bear.IsGetC4) { return; }

    }
}
