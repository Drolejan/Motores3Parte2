using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/Datos Item")]
public class ItemData : ScriptableObject
{
    public string nombreItem;
    public int valor;
    public AudioClip sonidoItem;
    public GameObject prefabItem;
    public ItemType tipo;
    public Sprite icono;
}
