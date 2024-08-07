using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes;

	public float sensitivityX = 15f;

	public float sensitivityY = 15f;

	public float minimumX = -360f;

	public float maximumX = 360f;

	public float minimumY = -60f;

	public float maximumY = 60f;

	public bool inverted;

	private float rotationY;

	private void Update()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			float y = base.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			if (inverted)
			{
				rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			}
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			base.transform.localEulerAngles = new Vector3(0f - rotationY, y, 0f);
		}
		else if (axes == RotationAxes.MouseX)
		{
			base.transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivityX, 0f);
		}
		else
		{
			if (inverted)
			{
				rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			}
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			base.transform.localEulerAngles = new Vector3(0f - rotationY, base.transform.localEulerAngles.y, 0f);
		}
	}

	private void Start()
	{
		if ((bool)base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}
}
