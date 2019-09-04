using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager instance;

    public GameObject ai;


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddAI()
    {
        Debug.Log("We are Instantiating AI");
        Instantiate(ai, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
