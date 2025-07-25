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
        public int health;
        public int damageMin;
        public int damageMax;
        public Sprite cardSprite;
        public List<DamageType> damageType;
        public CardSpeed cardSpeed;
        public enum CardType
        {
            Summon,
            Enchantment
        }
        public enum DamageType
        {
            Direct,
            OverTime
        }
        public enum CardSpeed
        {
            Burst,
            Slow
        }
    }
}
