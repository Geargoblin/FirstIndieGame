using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GearGoblinProductions
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public List<CardType> cardType;
        public List<CardSuit> cardSuit;
        public int value;
        public Sprite cardSprite;
        public GameObject prefab;
        public enum CardType
        {
            Standard,
            Tarot
        }
        public enum CardSuit
        {
            Wands,
            Pentacles,
            Swords,
            Cups
        }
    }
}
