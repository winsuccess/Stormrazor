using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIProfiles : MonoBehaviour
{
    public static int aiGold;
    public static int aiHealth;
    public Text aiGoldText;
    public Text aiHealthText;

    private void Awake()
    {
        aiGold = 0;
        aiHealth = 14440;
    }

    void Update()
    {
        //playerGoldText.text = playerGold.ToString();
        //playerHealthText.text = playerHealth.ToString();
    }
}
