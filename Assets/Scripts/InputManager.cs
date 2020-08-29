using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private BearController bearController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            bearController.Move(Direction.Left);
        }else if (Input.GetKey(KeyCode.D))
        {
            bearController.Move(Direction.Right);
        }else if (Input.GetKey(KeyCode.W))
        {
            bearController.Move(Direction.Up);
        }else if (Input.GetKey(KeyCode.S))
        {
            bearController.Move(Direction.Down);
        }
        else
        {
            bearController.Stop();
        }
    }


//    public void 
}
