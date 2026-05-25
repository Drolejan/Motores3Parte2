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
        DontDestroyOnLoad(gameObject);
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);//Previene que exista mas de 1 gamemanager
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

/*
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
    public event Action OnInventoryChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(ItemData item)
    {
        if (item == null) return;

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

    public void RemoveItem(ItemData item)
    {
        if (item == null) return;

        if (inventario.Remove(item))
        {
            OnInventoryChanged?.Invoke();
        }
    }

    public void AddMoney(int cantidad)
    {
        dinero += cantidad;
        OnDineroChanged?.Invoke(dinero);
    }
}
*/