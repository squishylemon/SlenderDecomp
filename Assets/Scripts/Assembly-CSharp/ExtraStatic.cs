using UnityEngine;

public class ExtraStatic : MonoBehaviour
{
	public bool top = true;

	private void Start()
	{
		Color color = base.GetComponent<Renderer>().material.color;
		color.a = 0.25f;
		base.GetComponent<Renderer>().material.color = color;
	}

	private void FixedUpdate()
	{
		Vector3 localPosition = base.transform.localPosition;
		base.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Random.value, Random.value);
		if (top)
		{
			if (Random.value > 0.5f)
			{
				localPosition.z += 0.02f;
				if (localPosition.z > 9.7f)
				{
					localPosition.z = 9.7f;
				}
			}
			else
			{
				localPosition.z -= 0.02f;
				if (localPosition.z < 9.2f)
				{
					localPosition.z = 9.2f;
				}
			}
		}
		else if (Random.value > 0.5f)
		{
			localPosition.z -= 0.02f;
			if (localPosition.z < -9.7f)
			{
				localPosition.z = -9.7f;
			}
		}
		else
		{
			localPosition.z += 0.02f;
			if (localPosition.z > -9.2f)
			{
				localPosition.z = -9.2f;
			}
		}
		base.transform.localPosition = localPosition;
		Color color = base.GetComponent<Renderer>().material.color;
		if (Random.value > 0.5f)
		{
			color.a += 0.02f;
			if (color.a > 0.25f)
			{
				color.a = 0.25f;
			}
		}
		else
		{
			color.a -= 0.02f;
			if (color.a < 0.05f)
			{
				color.a = 0.05f;
			}
		}
		base.GetComponent<Renderer>().material.color = color;
	}
}
