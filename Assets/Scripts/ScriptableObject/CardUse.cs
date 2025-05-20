using UnityEngine;

public class CardUse : MonoBehaviour, IInterectable
{
    [SerializeField] private CardData cardData;

    private Card _card;

    void Start()
    {
        _card = new Card(cardData);
    }

    public void Interect()
    {
        //_card.Use();
    }

    void Update()
    {
        // Exemplo de uso automático (opcional)
        // if (Input.GetKeyDown(KeyCode.Space))
        //     Interect();
    }
}
