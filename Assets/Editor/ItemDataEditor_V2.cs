using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(ItemData))]
public class ItemDataEditor_V2 : Editor
{
    private SerializedProperty nombreItem;
    private SerializedProperty tipo;
    private SerializedProperty valor;
    private SerializedProperty prefabItem;
    private SerializedProperty sonidoItem;

    private void OnEnable()
    {
        nombreItem = serializedObject.FindProperty("nombreItem");
        tipo = serializedObject.FindProperty("tipo");
        valor = serializedObject.FindProperty("valor");
        prefabItem = serializedObject.FindProperty("prefabItem");
        sonidoItem = serializedObject.FindProperty("sonidoItem");
    }

    public override void OnInspectorGUI()
    {
        // Sincroniza el objeto serializado con los datos reales
        serializedObject.Update();

        GUILayout.Space(10);
        GUILayout.Label("Item Configuration", EditorStyles.boldLabel);

        EditorGUILayout.HelpBox(
            "Este inspector utiliza SerializedProperty para editar los datos de forma segura y compatible con las herramientas de Unity.",
            MessageType.Info);

        GUILayout.Space(10);

        //------------------------------------------------
        // Información General
        //------------------------------------------------

        GUILayout.Label("Información General", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(nombreItem, new GUIContent("Nombre"));

        GUILayout.Space(10);

        //------------------------------------------------
        // Gameplay
        //------------------------------------------------

        GUILayout.Label("Gameplay", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(tipo, new GUIContent("Tipo"));
        EditorGUILayout.PropertyField(valor, new GUIContent("Valor"));

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Reset Valor"))
        {
            valor.intValue = 0;
        }

        if (GUILayout.Button("Valor Máximo"))
        {
            valor.intValue = 999;
        }

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        //------------------------------------------------
        // Recursos
        //------------------------------------------------

        GUILayout.Label("Recursos", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(prefabItem, new GUIContent("Prefab"));
        EditorGUILayout.PropertyField(sonidoItem, new GUIContent("Sonido"));

        GUILayout.Space(10);

        if (GUILayout.Button("Imprimir Datos"))
        {
            Debug.Log(
                $"Item: {nombreItem.stringValue}\n" +
                $"Tipo: {tipo.enumDisplayNames[tipo.enumValueIndex]}\n" +
                $"Valor: {valor.intValue}"
            );
        }

        // Aplica todos los cambios realizados
        serializedObject.ApplyModifiedProperties();
    }
}