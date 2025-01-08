using System;
using UnityEngine;

[Serializable]
public class Boundary
{
	public Vector2 min;

	public Vector2 max;

	public Boundary(float v)
	{
		min = Vector2.zero;
		max = Vector2.zero;
	}
}
