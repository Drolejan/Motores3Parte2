using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(ItemData))]
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
            EditorGUILayout.TextField("Nombre del item", item.nombreItem);

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

        if (GUILayout.Button("Valor Random"))
        {
            item.valor = Random.Range(1,999);
        }

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.Label("Recursos", EditorStyles.whiteLabel);

        item.prefabItem =
            (GameObject)EditorGUILayout.ObjectField(
                "Efecto Pickup Prefab",
                item.prefabItem,
                typeof(GameObject),
                false
            );

        item.sonidoItem =
            (AudioClip)EditorGUILayout.ObjectField(
                "Sonido Pickup",
                item.sonidoItem,
                typeof(AudioClip),
                false
            );

        GUILayout.Space(10);

        if (GUILayout.Button("Imprimir Datos"))
        {
            Debug.Log(
                "Nombre del Item: " + item.nombreItem +
                " | Tipo de item: " + item.tipo +
                " | Valor de venta: " + item.valor
            );
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(item);
        }

        GUILayout.Space(10);

        GUILayout.Label("Rareza Item", EditorStyles.whiteLabel);
        
        /*
        item.infoItem =
            (ItemInspector)EditorGUILayout.(
                "Efecto Pickup Prefab",
                item.infoItem,
                typeof(ItemInspector),
                false
            );
        */
        
    }
}
