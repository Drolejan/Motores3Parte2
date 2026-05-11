using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int dinero = 0;
    [SerializeField] private List<ItemData> inventario = new List<ItemData>();

    public int Dinero => dinero;
    public List<ItemData> Inventario => inventario;

    public event Action<int> OnDineroChanged;
    public event Action<ItemData> OnItemAdded;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        switch (item.tipo)
        {
            case ItemType.Moneda:
                dinero += item.valor;
                OnDineroChanged?.Invoke(dinero);
                break;

            case ItemType.Collecionable:
            case ItemType.Importante:
                inventario.Add(item);
                OnItemAdded?.Invoke(item);
                break;

            case ItemType.Vida:
                Debug.Log("Curar vida: " + item.valor);
                break;

            case ItemType.Stamina:
                Debug.Log("Recuperar stamina: " + item.valor);
                break;
        }
    }
}