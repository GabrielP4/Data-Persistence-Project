using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    public static HighScore Instance;
    public string playerName;
    public GameObject inputField;
    public GameObject highScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StoreName()
    {
        playerName = inputField.GetComponent<Text>().text;
        highScoreText.GetComponent<Text>().text = "Best score : " + playerName + " : 0";
    }
}
