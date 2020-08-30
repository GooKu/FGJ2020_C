using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ReturnMenuButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReturnMenu);
    }

    private void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
