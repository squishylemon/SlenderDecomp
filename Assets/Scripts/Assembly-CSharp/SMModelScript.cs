using UnityEngine;

public class SMModelScript : MonoBehaviour
{
	public SlenderMan SM;

	public PlayerScript view;

	private void Update()
	{
		view.cansee = false;
		view.drain = 0f;
	}

	private void OnWillRenderObject()
	{
		SM.CheckSanity();
	}
}
