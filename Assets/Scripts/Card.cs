using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewChamp", menuName ="Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public string type;
    public string skill;
    public float cooldown;
    public int manacost;
    public int health;
    public int mana;
    public int physicalDamage;
    public int magicalDamage;
    public int armor;
    public int magicResist;

}
