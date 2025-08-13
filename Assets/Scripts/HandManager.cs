using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GearGoblinProductions;

public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab; //Assign cardPrefab in inspector
    public Transform handTransform; //Root of the hand position
    public float fanSpread = 5f;
    public float cardSpacing = 5f; //horizontal spacing between cards
    public float verticalSpacing = 5f; //ensures that card fan looks like a fan
    public List<GameObject> cardsInHand = new List<GameObject>(); //hold a list of card objectss in hand
    public int startingHandSize = 5; //set starting hand size in inspector

    void Start()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            AddCardToHand();

        }
    }

    public void AddCardToHand()
    {
        //Instantiate the Card
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        UpdateHandVisuals();
    }

    void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;
        for (int i = 0; i < cardCount; i++)
        {
            //Set Card Rotation
            float rotationAngle = (fanSpread * (i - cardCount - 1) / 2f);
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            //Calculate Card Position Offset
            float horizontalOffset = i * (cardSpacing * (i - cardCount - 1) / 2f);

            float normalizedPosition = (2f * i / (cardCount -1) - 1f); //normalize card position between -1 and 1
            float verticalOffset = verticalSpacing * (1 - normalizedPosition * normalizedPosition);

            //Set Card Positions
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
