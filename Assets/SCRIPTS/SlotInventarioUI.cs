using TMPro;
using UnityEngine;

public class SlotInventarioUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nombreItemText;

    private ItemData item;

    public void Configurar(ItemData nuevoItem)
    {
        item = nuevoItem;
        nombreItemText.text = item.nombreItem;
    }

    public void UsarItem()
    {
        switch (item.tipo)
        {
            case ItemType.Vida:
                Debug.Log("Usaste item de vida: " + item.valor);
                GameManager.Instance.RemoveItem(item);
                break;

            case ItemType.Stamina:
                Debug.Log("Usaste item de stamina: " + item.valor);
                GameManager.Instance.RemoveItem(item);
                break;

            case ItemType.Importante:
                Debug.Log("Este item es importante y no se consume");
                break;

            case ItemType.Collecionable:
                Debug.Log("Este item es coleccionable");
                break;
        }
    }

    public void VenderItem()
    {
        if (item.tipo == ItemType.Importante)
        {
            Debug.Log("No puedes vender un item importante");
            return;
        }

        GameManager.Instance.AddMoney(item.valor);
        GameManager.Instance.RemoveItem(item);
    }
}