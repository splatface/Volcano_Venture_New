using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Saving
{

    private static SaveToFileFunc _saveData = new SaveToFileFunc();
    [System.Serializable]

    public struct SaveToFileFunc
    {
        public SaveData allSaveableData;

    }

    public static string SFileName()
    {
        string file = Application.persistentDataPath + "/save" + ".save";
        return file;
    }

    public static void Save()
    {
        HandleSaveData();

        File.WriteAllText(SFileName(), JsonUtility.ToJson(_saveData, true));
    }

    private static void HandleSaveData()
    {
        GameManager.Instance.InputData(ref _saveData.allSaveableData);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SFileName());

        _saveData = JsonUtility.FromJson<SaveToFileFunc>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
        GameManager.Instance.LoadData(_saveData.allSaveableData);
    }
}