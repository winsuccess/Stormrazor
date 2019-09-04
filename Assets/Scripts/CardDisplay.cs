using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardStats cs;
    public TextMeshProUGUI type;
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI skillText;
    public Image artwork;
    public TextMeshProUGUI manaCostText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI damageText;

    void Update()
    {
        if(GetComponent<CardStats>()!= null)
        {
            cs = GetComponent<CardStats>();
        if (cs.card == null)
            return;
        cardNameText.text = cs.cardName;
        skillText.text = cs.skill;
        type.text = cs.type;
        artwork.sprite = cs.card.artwork;
        manaCostText.text = cs.manacost.ToString();
        healthText.text = cs.currentHealth.ToString();
        manaText.text = cs.mana.ToString();
        damageText.text = cs.physicalDamage.ToString();
        }
    }

    public void DisplayView(CardStats cs)
    {
        if (cs.card == null)
            return;
        cardNameText.text = cs.cardName;
        skillText.text = cs.skill;
        type.text = cs.type;
        artwork.sprite = cs.card.artwork;
        manaCostText.text = cs.manacost.ToString();
        healthText.text = cs.currentHealth.ToString();
        manaText.text = cs.mana.ToString();
        damageText.text = cs.physicalDamage.ToString();
    }
}
