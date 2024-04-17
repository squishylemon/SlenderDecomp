using UnityEngine;

public class TentacleSpin : MonoBehaviour
{
	public bool otherway;

	private void FixedUpdate()
	{
		if (!otherway)
		{
			base.transform.Rotate(0f, 4.5f, 0f);
		}
		else
		{
			base.transform.Rotate(0f, -4.5f, 0f);
		}
	}
}
