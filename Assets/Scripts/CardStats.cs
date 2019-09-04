using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public Card card;

    public string cardName;
    public string type;
    public string skill;
    public float cooldown;
    public int manacost;
    public int mana;
    public int physicalDamage;
    public int magicalDamage;
    public int armor;
    public int magicResist;

    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        if (card == null)
            return;
        cardName = card.cardName;
        type = card.type;
        skill = card.skill;
        cooldown = card.cooldown;
        manacost = card.manacost;
        maxHealth = card.health;
        mana = card.mana;
        physicalDamage = card.physicalDamage;
        armor = card.armor;
        magicResist = card.magicResist;
        currentHealth = maxHealth;
    }

}
