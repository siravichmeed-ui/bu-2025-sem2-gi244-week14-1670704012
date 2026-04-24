using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {
        
        public Color TeamColor;

        
        public string PlayerName;
    }

    public void SaveColor()
    {
        String folder = Application.persistentDataPath;
        string fileName = "savefile.json";
        string fullPath = Path.Combine(folder, fileName);


        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        data.PlayerName = "NON";

        string json = JsonUtility.ToJson(data);
       File.WriteAllText(fullPath, json);

    }

    public void LoadColor()
    {
        string folder = Application.persistentDataPath;
        string fileName = "savefile.json";
        string fullPath = Path.Combine(folder, fileName);

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            TeamColor = data.TeamColor;
        }

    }
}