using UnityEngine;

public class NPCtalk : MonoBehaviour, IInteractivo
{
    [SerializeField] GameObject panelDialogo;
    public void Interact()
    {
        panelDialogo.SetActive(true);
        Invoke("cerrarPanel",3f);
    }
    public void cerrarPanel()
    {
        panelDialogo.SetActive(false);
    }
}
