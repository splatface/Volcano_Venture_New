using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    // the slider from the heatbarcode
    public Slider heatBar;

    // Singleton setup for GameManager
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("No GameManager");

            }

            return _instance;
        }

    }
    // creates these variables so that they can be accessed outside of Awake()
    public Scene currentScene;
    public string scene_name;

    // sets up GameManager 
    private void Awake()
    {
        // sets these here because GetActiveScene() cannot be called from outside Awake() or Start()
        currentScene = SceneManager.GetActiveScene();
        scene_name = currentScene.name;

        // if exists destroy, if not keep
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);

    }

    //setting up various variables
    public int level { get; set; } // for the levels within gameplay (level 1, 2, 3, etc.)
    public int state { get; set; } // for different types of screens: settings, pause, instructions, gameplay, etc.


    //sets the level based on the scene, used for saving and loading; the setting stuff is in Awake()
    public void levelNum()
    {
        if (scene_name == "Volcano") // the only level currently
        {
            level = 1;
        }
    }

    public void InputData(ref SaveData data)
    {
        data.currentHeat = heatBar.value;
        data.currentLevel = level;
    }

    public void LoadData(SaveData data)
    {
        heatBar.value = data.currentHeat;
        level = data.currentLevel;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // saves when presses left ctrl key
        {
            Saving.Save();
        }

        if (Input.GetKeyDown(KeyCode.RightControl)) // only for testing purposes as will load on start up later on
        {
            Saving.Load();
        }
    }


}

[System.Serializable]
public class SaveData
{
    public float currentHeat;
    public int currentLevel;

}