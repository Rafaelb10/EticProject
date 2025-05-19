using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public enum CardType
    {
        Efeito,
        Personagem,
        Terreno
    }

    [Header("Tipo da Carta")]
    public CardType _cardType;

    [Header("Normal")]
    public Sprite _sprite;
    public int _cost;
    public string _description;

    [Header("Character attributes")]
    public int _life;
    public int _attack;
    public int _defense;

}
