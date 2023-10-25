using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static string input;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerTimeText;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string playerName = input; 
            float playerTime = GameManager.elapsedTime; 

           
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.SetFloat("PlayerTime", playerTime);

            
            playerNameText.text = "Name: " + playerName;
            playerTimeText.text = "Time: " + playerTime.ToString("0.00") + "s";
        }
    }

}
