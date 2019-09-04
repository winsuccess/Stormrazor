using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActions : MonoBehaviour
{
    public CardStats [] mCard;
    public CardStats [] eCard;
    public CardStats thisCard;
    public CardStats pTarget;

    public Transform[] myCard;
    public Transform[] enemyCard;

    private void Start()
    {
        if (thisCard.GetComponent<CardStats>() != null)
            thisCard = this.GetComponent<CardStats>();
    }

    public void Attack(CardStats target)
    {
        target.currentHealth -= thisCard.physicalDamage * 100 / (100 + target.armor);
    }

    public void UseSkill()
    {

    }
}
