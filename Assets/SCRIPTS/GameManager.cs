using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int dinero = 0;
    [SerializeField] private List<ItemData> inventario = new List<ItemData>();

    public int Dinero => dinero;
    public IReadOnlyList<ItemData> Inventario => inventario;

    public event Action<int> OnDineroChanged;
    public event Action<ItemData> OnItemAdded;
    public event Action OnInventoryChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);//Previene que exista mas de 1 gamemanager
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(ItemData item)
    {
        //if (item == null) return; //Esta linea previene errores

        switch (item.tipo)
        {
            case ItemType.Moneda:
                AddMoney(item.valor);
                break;

            case ItemType.Vida:
            case ItemType.Stamina:
            case ItemType.Collecionable:
            case ItemType.Importante:
                inventario.Add(item);
                OnInventoryChanged?.Invoke();
                break;
        }
    }

    public void AddMoney(int cantidad)
    {
        dinero += cantidad;
        OnDineroChanged?.Invoke(dinero);
    }

    public void RemoveItem(ItemData item)
    {
        //if (item == null) return; //Linea para prevenir errores

        if (inventario.Remove(item))
        {
            OnInventoryChanged?.Invoke();
        }
    }
}
