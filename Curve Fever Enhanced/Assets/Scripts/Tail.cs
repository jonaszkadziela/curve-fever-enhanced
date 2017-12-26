using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
	public float pointSpacing = 0.1f;
	public Transform head;

	private List<Vector2> points;
	private LineRenderer line;
	private EdgeCollider2D col;
	private Color tailColor;
	private bool drawLine = true;

	void Start()
	{
		line = GetComponent<LineRenderer>();
		col = GetComponent<EdgeCollider2D>();

		tailColor = GameManager.Instance.getTailColor();
		line.startColor = tailColor;
		line.endColor = tailColor;

		points = new List<Vector2>();
		SetPoint();
	}

	void Update()
	{
		if (head == null)
		{
			return;
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (drawLine)
			{
				drawLine = false;
			}
			else
			{
				drawLine = true;
			}
		}
		if (Vector3.Distance(points.Last(), head.position) > pointSpacing && drawLine)
		{
			SetPoint();
		}
	}

	void SetPoint()
	{
		if (points.Count > 1)
		{
			col.points = points.ToArray<Vector2>();
		}
		points.Add(head.position);
		line.positionCount = points.Count;
		line.SetPosition(points.Count - 1, head.position);
	}
}
