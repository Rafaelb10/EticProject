using UnityEngine;
using static CardData;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public enum CardType
    {
        Effects,
        Character,
        Terrain,
        Equipment
    }

    public enum EffectType
    {
        Gain,
        Lost
    }

    public enum Attributes
    {
        Life,
        Attack,
        Defense
    }

    [Header("Card Type")]
    [SerializeField] private CardType _cardType;

    [Header("Normal")]
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private int _cost;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    [Header("Character attributes")]
    [SerializeField] private int _life;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;

    [Header("Type of land")]
    [SerializeField] private EffectType _effectTypeTerrain;
    [SerializeField] private Attributes _attributesTerrain;

    [Header("Type of Equipament")]
    [SerializeField] private Attributes _attributesEquipment;

    public CardType CardType1 { get => _cardType; set => _cardType = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }
    public GameObject GameObject { get => _gameObject; set => _gameObject = value; }
    public int Cost { get => _cost; set => _cost = value; }
    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public int Life { get => _life; set => _life = value; }
    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public EffectType EffectTypeTerrain { get => _effectTypeTerrain; set => _effectTypeTerrain = value; }
    public Attributes AttributesTerrain { get => _attributesTerrain; set => _attributesTerrain = value; }
    public Attributes AttributesEquipment { get => _attributesEquipment; set => _attributesEquipment = value; }
}
