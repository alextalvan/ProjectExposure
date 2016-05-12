using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(EdgeCollider2D))]
public class EdgeEditor : Editor
{

	//SerializedProperty pointArrayProp;

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		//return;
		EdgeCollider2D edgeCol = (EdgeCollider2D) target;

		Vector2[] points = edgeCol.points;
		int pointCount = edgeCol.pointCount;

		//Vector2[] newPoints = new Vector2[pointCount];

		for(int i=0; i < pointCount; ++i)
			points[i] = EditorGUILayout.Vector2Field("Point " + i.ToString(), points[i]);

		edgeCol.points = points;

	}
   
}
