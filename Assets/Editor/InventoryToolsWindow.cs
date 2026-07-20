using UnityEditor;
using UnityEngine;

public class InventoryToolsWindow : EditorWindow
{
    private string nombre = "";
    private ItemType tipo;
    private int valor = 100;

    [MenuItem("Tools/Inventory Tools")]
    public static void ShowWindow()
    {
        GetWindow<InventoryToolsWindow>("Inventory Tools");
    }

    private void OnGUI()
    {
        GUILayout.Label(
            "Crear Nuevo Item",
            EditorStyles.boldLabel);

        nombre = EditorGUILayout.TextField(
            "Nombre",
            nombre);

        tipo = (ItemType)EditorGUILayout.EnumPopup(
            "Tipo",
            tipo);

        valor = EditorGUILayout.IntField(
            "Valor",
            valor);

        GUILayout.Space(10);

        if (GUILayout.Button("Crear Item"))
        {
            ItemData nuevoItem =
                ScriptableObject.CreateInstance<ItemData>();

            nuevoItem.nombreItem = nombre;
            nuevoItem.tipo = tipo;
            nuevoItem.valor = valor;

            AssetDatabase.CreateAsset(
                nuevoItem,
                $"Assets/Items/{nombre}.asset");

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Selection.activeObject = nuevoItem;

            nombre = "";
            tipo = ItemType.Money;
            valor = 100;
        }
    }
}