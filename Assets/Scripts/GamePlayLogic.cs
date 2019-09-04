using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayLogic : MonoBehaviour
{
    public int tick = 1;
    public Transform[] myCard;
    public Transform[] enemyCard;
    public CardStats[] mCard;
    public CardStats[] eCard;
    public CardStats[] target;
    public CardStats[] pTarget;

    void Start()
    {
        myCard = new Transform[5];
        enemyCard = new Transform[5];
        mCard = new CardStats[5];
        eCard = new CardStats[5];
        target = new CardStats[5];
        pTarget = new CardStats[5];
    }

    public void Fight()
    {
        for (int i = 0; i < 5; ++i)
        {
            if(myCard[i].GetComponent<CardStats>()!= null)
                mCard[i] = myCard[i].GetComponent<CardStats>();
            if (enemyCard[i].GetComponent<CardStats>() != null)
                eCard[i] = enemyCard[i].GetComponent<CardStats>();
        }

        for (int i = 0; i < 5; ++i)
        {
            if ((new[] { "Marksman", "Mage" }).Contains(mCard[i].type))
                target[i] = eCard[2];
            else if ((new[] { "Juggernaut", "Battlemage", "Vanguard" }).Contains(mCard[i].type))
                target[i] = eCard[i];
            else if ((new[] { "Burst", "Assassin" }).Contains(mCard[i].type))
            {
                target[i] = eCard[0];
                for (int j = 1; j < 5; ++j)
                {
                    if (eCard[j].currentHealth < target[i].currentHealth)
                        target[i] = eCard[j];
                }
            }
            else if ((new[] { "Catcher", "Diver" }).Contains(mCard[i].type))
            {
                int distance = 5;
                for (int j = 0; j < 5; ++j)
                {
                    if (eCard[j].type == "Marksman" || eCard[j].type == "Mage")
                    {
                        if (Mathf.Abs(j - i) < distance)
                        {
                            target[i] = eCard[j];
                            distance = Mathf.Abs(j - i);
                        }
                    }
                }

                if (target[i] == null)
                {
                    distance = 5;
                    for (int j = 0; j < 5; ++j)
                    {
                        if (eCard[j].type == "Enchanter" || eCard[j].type == "Burst")
                        {
                            if (Mathf.Abs(j - i) < distance)
                            {
                                target[i] = eCard[j];
                                distance = Mathf.Abs(j - i);
                            }
                        }
                    }
                }

                if (target[i] == null)
                {
                    target[i] = eCard[i];
                }
            }
            else if ((new[] { "Enchanter", "Warden" }).Contains(mCard[i].type))
            {
                int distance = 5;
                for (int j = 0; j < 5; ++j)
                {
                    if (mCard[j].type == "Marksman" || mCard[j].type == "Mage" || eCard[j].type == "Burst")
                    {
                        if (Mathf.Abs(j - i) < distance)
                        {
                            pTarget[i] = mCard[j];
                            distance = Mathf.Abs(j - i);
                        }
                    }
                }

                if (pTarget[i] == null)
                {
                    distance = 5;
                    for (int j = 0; j < 5; ++j)
                    {
                        if (mCard[j].type == "Battlemage" || mCard[j].type == "Juggernaut")
                        {
                            if (Mathf.Abs(j - i) < distance)
                            {
                                target[i] = eCard[j];
                                distance = Mathf.Abs(j - i);
                            }
                        }
                    }
                }

                if (pTarget[i] == null)
                {
                    if (i > 0)
                        pTarget[i] = mCard[i - 1];
                    else
                        pTarget[i] = mCard[i + 1];
                }

                target[i] = eCard[i];
            }

        }

        switch (tick)
        {
            case 1:
                Debug.Log("Tick =1");

                for (int i = 0; i < 5; i++)
                {
                    if (mCard[i].type == "Marksman" || mCard[i].type == "Mage")
                    {
                        if (target[i] != null)
                            target[i].currentHealth -= mCard[i].physicalDamage * 100 / (100 + target[i].armor);
                        else
                            PlayerProfiles.playerHealth -= mCard[i].physicalDamage;
                    }

                }

                tick++;
                break;
            case 2:
                Debug.Log("Tick =2");

                for (int i = 0; i < 5; i++)
                {
                    if (mCard[i].type == "Battlemage" || mCard[i].type == "Juggernaut" || mCard[i].type == "Catcher")
                    {
                        if (target[i] != null)
                            target[i].currentHealth -= mCard[i].physicalDamage * 100 / (100 + target[i].armor);
                        else
                            PlayerProfiles.playerHealth -= mCard[i].physicalDamage;
                    }
                }
                tick++;
                break;
            case 3:
                Debug.Log("Tick =3");

                for (int i = 0; i < 5; i++)
                {
                    if (mCard[i].type == "Burst" || mCard[i].type == "Diver" || mCard[i].type == "Assassin")
                    {
                        if (target[i] != null)
                            target[i].currentHealth -= mCard[i].physicalDamage * 100 / (100 + target[i].armor);
                        else
                            PlayerProfiles.playerHealth -= mCard[i].physicalDamage;
                    }
                }
                tick++;
                break;
            case 4:
                Debug.Log("Tick =4");

                for (int i = 0; i < 5; i++)
                {
                    if (mCard[i].type == "Marksman" || mCard[i].type == "Enchanter" || mCard[i].type == "Warden")
                    {
                        if (target[i] != null)
                            target[i].currentHealth -= mCard[i].physicalDamage * 100 / (100 + target[i].armor);
                        else
                            PlayerProfiles.playerHealth -= mCard[i].physicalDamage;
                    }
                }

                tick++;
                break;
            case 5:
                Debug.Log("Tick =5");

                for (int i = 0; i < 5; i++)
                {
                    if (mCard[i].type == "Vanguard")
                    {
                        if (target[i] != null)
                            target[i].currentHealth -= mCard[i].physicalDamage * 100 / (100 + target[i].armor);
                        else
                            PlayerProfiles.playerHealth -= mCard[i].physicalDamage;
                    }
                }

                tick = 1;
                break;
        }
    }

}
