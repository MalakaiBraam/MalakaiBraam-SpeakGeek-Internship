using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private string input;

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }

    public void ReadInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
}
