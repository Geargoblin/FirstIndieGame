using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GearGoblinProductions;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public Image[] typeImages;
    public Image displayImage;
    private Color[] cardColors = {
        Color.red,
        Color.blue
    };
    private Color[] typeColors = {
        new Color(0.8f,0f,0f),
        new Color(0.8f,0f,0.8f),
    };
    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        //Update main cardImage color based on Primary Card Type and Data
        cardImage.color = cardColors[(int)cardData.cardType[0]];

        nameText.text = cardData.cardName;
        displayImage.sprite = cardData.cardSprite;

        //Update type images
        for (int i = 0; i < typeImages.Length; i++)
        {
            if (i < cardData.cardType.Count)
            {
                typeImages[i].gameObject.SetActive(true);
                typeImages[i].color = typeColors[(int)cardData.cardType[i]];
            }
            else
            {
                typeImages[i].gameObject.SetActive(false);
            }
        }

    }
}
