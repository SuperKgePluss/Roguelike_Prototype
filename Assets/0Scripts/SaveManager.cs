using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int bestScore;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    string path;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        path = Application.persistentDataPath + "/save.json";
    }

    public void SaveScore(int score)
    {
        SaveData data = new SaveData();

        data.bestScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    public int LoadScore()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data =
                JsonUtility.FromJson<SaveData>(json);

            return data.bestScore;
        }

        return 0;
    }
}