using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class HighScore : MonoBehaviour
{
    public static HighScore Instance;
    public string currentPlayerName;
    public string highScorePlayerName;
    public GameObject inputField;
    public GameObject highScoreText;
    public int highestScore;
    MainManager mainManager;
    private void Awake()
    {
        LoadPlayerData();
        DisplayHighestScore();
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

    }
    public void StoreScore(int points)
    {
        highestScore = points;
    }

    public void DisplayHighestScore()
    {
        highScoreText.GetComponent<Text>().text = "Best score : " + highScorePlayerName + " : " + highestScore;
    }
    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highestScore;
    }
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.highestScore = highestScore;
        data.highScorePlayerName = highScorePlayerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highestScore = data.highestScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }
}
