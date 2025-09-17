using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

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

    private void Awake()
    {

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
    public int level { get; set; }
    public int state { get; set; }

    public int heatBarCurrent { get; set; }

}
