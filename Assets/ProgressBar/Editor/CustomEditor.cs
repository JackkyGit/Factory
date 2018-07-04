using UnityEngine;
using UnityEditor;
using ProgressBar.Utils;
using ProgressBar;

//[CustomEditor(typeof(ProgressValue))]

//public class ProgressValueEditor : Editor
//{
//	public override void OnInspectorGUI()
//	{
//		ProgressValue myTarget = (ProgressValue) target;

//		var temp= EditorGUILayout.FloatField("Progress" , myTarget.AsFloat);
//		myTarget.Set(temp);
//		//EditorGUILayout.LabelField("Level" , myTarget.Level.ToString());
//	}
//}

// [CustomPropertyDrawer(typeof(ProgressValue))]
// public class ProgressValueDrawer : PropertyDrawer
// {
// 	// Draw the property inside the given rect
// 	public override void OnGUI(Rect position , SerializedProperty property , GUIContent label)
// 	{
// 		// Using BeginProperty / EndProperty on the parent property means that
// 		// prefab override logic works on the entire property.
// 		EditorGUI.BeginProperty(position , label , property);
// 
// 		// Draw label
// 		position = EditorGUI.PrefixLabel(position , GUIUtility.GetControlID(FocusType.Passive) , label);
// 
// 		// Don't make child fields be indented
// 		var indent = EditorGUI.indentLevel;
// 		EditorGUI.indentLevel = 0;
// 
// 		// Calculate rects
// 		var amountRect = new Rect(position.x , position.y , 30 , position.height);
// 		var target = (property.serializedObject.targetObject as ProgressBarBehaviour);
// 		// Draw fields - passs GUIContent.none to each so they are drawn without labels
// 		EditorGUI.FloatField(amountRect , 0.5f);
// 		// Set indent back to what it was
// 		EditorGUI.indentLevel = indent;
// 
// 		EditorGUI.EndProperty();
// 	}
//}