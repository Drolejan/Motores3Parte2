using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemInspector))]
public class ItemVisualDrawer : PropertyDrawer
{
    public override void OnGUI(
        Rect position,
        SerializedProperty property,
        GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty icono =
            property.FindPropertyRelative("icono");

        SerializedProperty rareza =
            property.FindPropertyRelative("rareza");

        SerializedProperty colorRareza =
            property.FindPropertyRelative("colorRareza");

        float lineHeight =
            EditorGUIUtility.singleLineHeight;

        float spacing =
            EditorGUIUtility.standardVerticalSpacing;

        Rect iconoRect = new Rect(
            position.x,
            position.y,
            position.width,
            lineHeight
        );

        Rect rarezaRect = new Rect(
            position.x,
            position.y + lineHeight + spacing,
            position.width,
            lineHeight
        );

        Rect colorRect = new Rect(
            position.x,
            position.y + (lineHeight + spacing) * 2,
            position.width,
            lineHeight
        );

        EditorGUI.PropertyField(
            iconoRect,
            icono,
            new GUIContent("Icono")
        );

        EditorGUI.PropertyField(
            rarezaRect,
            rareza,
            new GUIContent("Rareza")
        );

        EditorGUI.PropertyField(
            colorRect,
            colorRareza,
            new GUIContent("Color de Rareza")
        );

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(
        SerializedProperty property,
        GUIContent label)
    {
        float lineHeight =
            EditorGUIUtility.singleLineHeight;

        float spacing =
            EditorGUIUtility.standardVerticalSpacing;

        return lineHeight * 3 + spacing * 2;
    }
}