using UnityEngine;
using TMPro;

public class dineroUI : MonoBehaviour
{
    TextMeshProUGUI dinero;
    void Start()
    {
        dinero=GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnDineroChanged+=updateDinero;
        updateDinero(GameManager.Instance.Dinero);
    }

    void updateDinero(int valor)
    {
        dinero.text= "Gold: "+ valor;
    }
}

