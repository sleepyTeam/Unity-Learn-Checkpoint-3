using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public string playerName;
    public static DataManager instance;
    public MainManager mM;
    public Text hiScore;
    public int score;
    public int BestScore;
    public string BestPlayer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            mM = GameObject.Find("MainManager").GetComponent<MainManager>();
            hiScore = GameObject.Find("HiScore").GetComponent<Text>();
            score = mM.m_Points;
        }
        else
        {
            mM = null;
            hiScore = null;
            score = 0;
        }

        if(score > BestScore && hiScore != null)
        {
            hiScore.text = ("Best Score : " + playerName + " : " + score);
            BestPlayer = playerName;
            BestScore = score;
        }
        else
        {
            hiScore.text = ("Best Score : " + BestPlayer + " : " + BestScore);
        }

        if(mM.m_GameOver == true)
        {
            Save();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayer;
        public int score;
        public int BestScore;
       
    }

   public void Save()
    {
        SaveData data = new SaveData();
        data.BestPlayer = BestPlayer;
        data.score = score;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson < SaveData >(json);

            BestScore = data.BestScore;
            BestPlayer = data.BestPlayer;
        }
    }
}
