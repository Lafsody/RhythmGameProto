using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
	[SerializeField]
	private Track track;

	[SerializeField]
	private Canvas canvas;
	[SerializeField]
	private GameObject keyPrefabLineA;
	[SerializeField]
	private GameObject keyPrefabLineB;

	public float distanceScale;

	void Start()
	{
		GenerateKeyLineA();
		GenerateKeyLineB();
	}

	void GenerateKeyLineA()
	{
		foreach (var note in track.lineA)
		{
			var newKey = Instantiate(keyPrefabLineA);
			newKey.transform.position += Vector3.right * note.keyTime * distanceScale;
			newKey.transform.SetParent(canvas.transform, false);
		}
	}

	void GenerateKeyLineB()
	{
		foreach (var note in track.lineB)
		{
			var newKey = Instantiate(keyPrefabLineB);
			newKey.transform.position += Vector3.right * note.keyTime * distanceScale;
			newKey.transform.SetParent(canvas.transform, false);
		}
	}
}
