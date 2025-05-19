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
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_cost"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_description"));

        if (cardType == CardData.CardType.Personagem)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Character attributes", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_life"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_attack"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_defense"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}