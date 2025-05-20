using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int hp = 10;
    public int damage = 2;
    public int def = 1;

    public void Modify(CardData.Attributes attribute, CardData.EffectType effect)
    {
        int delta = (effect == CardData.EffectType.Gain) ? 1 : -1;

        switch (attribute)
        {
            case CardData.Attributes.Life:
                hp += delta;
                break;
            case CardData.Attributes.Attack:
                damage += delta;
                break;
            case CardData.Attributes.Defense:
                def += delta;
                break;
        }

        Debug.Log($"Player modified: {attribute} -> {(effect == CardData.EffectType.Gain ? "+" : "-")}1");
    }
}
