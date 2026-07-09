using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemData item = (ItemData)target;

        GUILayout.Space(10);
        GUILayout.Label("Item Configuration", EditorStyles.boldLabel);

        EditorGUILayout.HelpBox(
            "Configura aquí los datos principales del item.",
            MessageType.Info
        );

        GUILayout.Space(10);

        GUILayout.Label("Información General", EditorStyles.boldLabel);

        item.nombreItem =
            EditorGUILayout.TextField("Nombre", item.nombreItem);

        GUILayout.Space(10);

        GUILayout.Label("Gameplay", EditorStyles.boldLabel);

        item.tipo =
            (ItemType)EditorGUILayout.EnumPopup("Tipo", item.tipo);

        item.valor =
            EditorGUILayout.IntField("Valor", item.valor);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Reset Valor"))
        {
            item.valor = 0;
        }

        if (GUILayout.Button("Valor Máximo"))
        {
            item.valor = 999;
        }

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.Label("Recursos", EditorStyles.boldLabel);

        item.prefabItem =
            (GameObject)EditorGUILayout.ObjectField(
                "Prefab",
                item.prefabItem,
                typeof(GameObject),
                false
            );

        item.sonidoItem =
            (AudioClip)EditorGUILayout.ObjectField(
                "Sonido",
                item.sonidoItem,
                typeof(AudioClip),
                false
            );

        GUILayout.Space(10);

        if (GUILayout.Button("Imprimir Datos"))
        {
            Debug.Log(
                "Item: " + item.nombreItem +
                " | Tipo: " + item.tipo +
                " | Valor: " + item.valor
            );
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(item);
        }
    }
}