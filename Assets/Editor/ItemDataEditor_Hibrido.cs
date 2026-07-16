using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor_Hibrido : Editor
{
    private SerializedProperty visualProperty;

    private void OnEnable()
    {
        visualProperty = serializedObject.FindProperty("infoItem");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ItemData item = (ItemData)target;

        GUILayout.Space(10);

        GUILayout.Label(
            "Item Configuration",
            EditorStyles.boldLabel
        );

        EditorGUILayout.HelpBox(
            "Inspector híbrido: algunos campos se dibujan manualmente y la configuración visual utiliza SerializedProperty y PropertyDrawer.",
            MessageType.Info
        );

        GUILayout.Space(10);

        // ---------------------------------------------
        // Información general
        // ---------------------------------------------

        GUILayout.Label(
            "Información General",
            EditorStyles.boldLabel
        );

        item.nombreItem = EditorGUILayout.TextField(
            "Nombre",
            item.nombreItem
        );

        /*
        item.descripcion = EditorGUILayout.TextArea(
            item.descripcion,
            GUILayout.MinHeight(50)
        );
        */

        GUILayout.Space(10);

        // ---------------------------------------------
        // Gameplay
        // ---------------------------------------------

        GUILayout.Label(
            "Gameplay",
            EditorStyles.boldLabel
        );

        item.tipo = (ItemType)EditorGUILayout.EnumPopup(
            "Tipo",
            item.tipo
        );

        item.valor = EditorGUILayout.IntField(
            "Valor",
            item.valor
        );

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

        // ---------------------------------------------
        // Configuración visual mediante PropertyDrawer
        // ---------------------------------------------

        GUILayout.Label(
            "Configuración Visual",
            EditorStyles.boldLabel
        );

        if (visualProperty != null)
        {
            EditorGUILayout.PropertyField(
                visualProperty,
                new GUIContent("Visual"),
                true
            );
        }
        else
        {
            EditorGUILayout.HelpBox(
                "No se encontró una propiedad llamada 'visual' en ItemData.",
                MessageType.Error
            );
        }

        GUILayout.Space(10);

        // ---------------------------------------------
        // Recursos
        // ---------------------------------------------

        GUILayout.Label(
            "Recursos",
            EditorStyles.boldLabel
        );

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

        // ---------------------------------------------
        // Herramientas
        // ---------------------------------------------

        if (GUILayout.Button("Imprimir Datos"))
        {
            string rareza = item.infoItem != null
                ? item.infoItem.rareza.ToString()
                : "Sin visual";

            Debug.Log(
                $"Item: {item.nombreItem}\n" +
                $"Tipo: {item.tipo}\n" +
                $"Valor: {item.valor}\n" +
                $"Rareza: {rareza}"
            );
        }

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(item);
        }
    }
}