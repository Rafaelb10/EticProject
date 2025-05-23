using UnityEngine;
using UnityEngine.Events;

public class CardBuyManager : MonoBehaviour
{
    public UnityEvent OnBuyCharacter;
    public UnityEvent OnBuyEffect;
    public UnityEvent OnBuyTerrain;
    public UnityEvent OnBuyEquipment;

    public void BuyCharacter()
    {
        OnBuyCharacter?.Invoke();
    }

    public void BuyEffect()
    {
        OnBuyEffect?.Invoke();
    }

    public void BuyTerrain()
    {
        OnBuyTerrain?.Invoke();
    }

    public void BuyEquipment()
    {
        OnBuyEquipment?.Invoke();
    }
}
