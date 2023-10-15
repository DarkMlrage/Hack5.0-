using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferenceManager : MonoBehaviour
{
    [SerializeField] public SunPowerControler sunPowerControler;    

    private static GameReferenceManager instance;

    public static GameReferenceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameReferenceManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameReferenceManager");
                    instance = singletonObject.AddComponent<GameReferenceManager>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }        
    }

    void Update()
    {        
    }
}
