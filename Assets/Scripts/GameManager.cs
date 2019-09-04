using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static bool beginGame;
    public string gameType;

    void Awake()
    {
        if (instance == null)
            instance = this;
        beginGame = false;
    }

    void Start()
    {
    }

     void Update()
    {

    }


}

