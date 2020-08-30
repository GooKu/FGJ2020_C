using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private BearController bear;

    private void Start()
    {
        EventManager.AddListen(GameEvents.GameOver, Stop);
        EventManager.AddListen(GameEvents.GameEnd, Stop);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListen(GameEvents.GameOver, Stop);
        EventManager.RemoveListen(GameEvents.GameEnd, Stop);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.O))
        {
            if (bear.IsGetC4) { return; }
            bear.Stealth();
        }else if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.O))
        {
            bear.CancelStealth();
        }else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.P))
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
        else if (Input.GetKey(KeyCode.A))
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

    private void Stop(object[] callBack)
    {
        enabled = false;
    }
}
