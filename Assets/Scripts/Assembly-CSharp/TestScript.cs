using UnityEngine;

public class TestScript : MonoBehaviour
{
	public bool testing;

	public bool valid = true;

	public bool hidden = true;

	public Transform player;

	public Transform lhand;

	public Transform rhand;

	private void OnWillRenderObject()
	{
		if (testing)
		{
			RaycastHit hitInfo;
			if (Physics.Raycast(player.position, (base.transform.position - player.position).normalized, out hitInfo) && hitInfo.collider.gameObject == base.gameObject)
			{
				hidden = false;
			}
			if (hidden && Physics.Raycast(player.position, (lhand.position - player.position).normalized, out hitInfo) && hitInfo.collider.gameObject == base.gameObject)
			{
				hidden = false;
			}
			if (hidden && Physics.Raycast(player.position, (rhand.position - player.position).normalized, out hitInfo) && hitInfo.collider.gameObject == base.gameObject)
			{
				hidden = false;
			}
		}
	}

	private void OnCollisionStay(Collision info)
	{
		if (testing)
		{
			valid = false;
		}
	}
}
