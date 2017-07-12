using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Track))]
public class TrackDrawer : Editor
{
	SerializedProperty lineA;
	SerializedProperty lineB;
	SerializedProperty song;

	void OnEnable()
	{
		lineA = serializedObject.FindProperty("lineA");
		lineB = serializedObject.FindProperty("lineB");
		song = serializedObject.FindProperty("song");
	}

	public void ShowArrayProperty(SerializedProperty list)
    {
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField(new GUIContent("Track " + list.name));
		EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
		EditorGUILayout.EndHorizontal();

		EditorGUI.indentLevel += 1;

		for (int i = 0; i < list.arraySize; i++)
		{
			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.LabelField(new GUIContent("Note " + i));

			EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i).FindPropertyRelative("keyTime"),
				new GUIContent(""));

			EditorGUILayout.EndHorizontal();
		}            
		EditorGUI.indentLevel -= 1;
    }

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		ShowArrayProperty(lineA);
		ShowArrayProperty(lineB);

		EditorGUILayout.PropertyField(song, new GUIContent("Song: "));

		serializedObject.ApplyModifiedProperties();
	}
}
