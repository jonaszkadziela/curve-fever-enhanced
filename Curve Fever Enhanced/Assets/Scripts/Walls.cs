using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Walls : MonoBehaviour
{
	public LineRenderer line;
	private EdgeCollider2D col;

	private float lineWidth;

	void Start()
	{
		lineWidth = 0.06f * Mathf.Max(Settings.BattlefieldWidth / 6.75f, Settings.BattlefieldHeight / 6.75f);
		Vector3[] positions = new[]
		{
			new Vector3(-Settings.BattlefieldWidth, Settings.BattlefieldHeight, 0f),
			new Vector3(Settings.BattlefieldWidth, Settings.BattlefieldHeight, 0f),
			new Vector3(Settings.BattlefieldWidth, -Settings.BattlefieldHeight, 0f),
			new Vector3(-Settings.BattlefieldWidth, -Settings.BattlefieldHeight, 0f),
			new Vector3(-Settings.BattlefieldWidth, Settings.BattlefieldHeight + lineWidth / 2f, 0f)
		};
		line = GetComponent<LineRenderer>();
		col = GetComponent<EdgeCollider2D>();
		line.startWidth = lineWidth;
		line.endWidth = line.startWidth;
		line.SetPositions(positions);
		col.points = ConvertArray(positions);
	}

	Vector2[] ConvertArray(Vector3[] v3)
	{
		Vector2[] v2 = new Vector2[v3.Length];
		for (int i = 0; i < v3.Length; i++)
		{
			Vector3 tempV3 = v3[i];
			v2[i] = new Vector2(tempV3.x, tempV3.y);
		}
		return v2;
	}

}