using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardData))]
public class CardDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var cardTypeProp = serializedObject.FindProperty("_cardType");
        var cardType = (CardData.CardType)cardTypeProp.enumValueIndex;

        EditorGUILayout.PropertyField(cardTypeProp);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_sprite"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_gameObject"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_gameObject2"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_name"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_cost"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_description"));

        if (cardType == CardData.CardType.Character)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_life"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_attack"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_defense"));
        }

        if (cardType == CardData.CardType.Terrain)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_effectTypeTerrain"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_attributesTerrain"));
        }

        if (cardType == CardData.CardType.Equipment)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_attributesEquipment"));
        }

        if (cardType == CardData.CardType.Effects)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_effectClass"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}