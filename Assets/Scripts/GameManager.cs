using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public string PlayerName;
        public int Score;
    }

    public static GameManager Instance;

    public string PlayerName, BestPlayerName;
    public int BestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        BestScore = 0;
        Load();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Save(int scoreValue)
    {
        SaveData data = new SaveData();
        BestPlayerName = PlayerName;
        data.PlayerName = BestPlayerName;
        BestScore = scoreValue;
        data.Score = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile_Data_Persistence.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "//savefile_Data_Persistence.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayerName = data.PlayerName;
            BestScore = data.Score;
        }
    }
}
