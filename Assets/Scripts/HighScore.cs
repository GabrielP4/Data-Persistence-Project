using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    public static HighScore Instance;
    public string currentPlayerName;
    public string highScorePlayerName;
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
        currentPlayerName = inputField.GetComponent<Text>().text;
        //highScoreText.GetComponent<Text>().text = "Best score : " + highScorePlayerName + " : 0";
    }
}
