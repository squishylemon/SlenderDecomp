using UnityEngine;

public class SprintScript : MonoBehaviour
{
	public float walkSpeed = 3f;

	public float crchSpeed = 1f;

	public float runSpeed = 8f;

	public float jogSpeed = 3.5f;

	public PlayerScript view;

	private CharacterMotor chMotor;

	private Transform tr;

	private float dist;

	private void Start()
	{
		chMotor = GetComponent<CharacterMotor>();
		tr = base.transform;
		CharacterController component = GetComponent<CharacterController>();
		dist = component.height / 2f;
	}

	private void FixedUpdate()
	{
		float to = 1f;
		float maxForwardSpeed = walkSpeed;
		if (Input.GetButton("Jog/Sprint") && chMotor.grounded && view.stamina > 10f)
		{
			maxForwardSpeed = ((view.scared <= 0) ? jogSpeed : runSpeed);
		}
		chMotor.movement.maxForwardSpeed = maxForwardSpeed;
		float y = tr.localScale.y;
		Vector3 localScale = tr.localScale;
		Vector3 position = tr.position;
		localScale.y = Mathf.Lerp(tr.localScale.y, to, 5f * Time.deltaTime);
		tr.localScale = localScale;
		position.y += dist * (tr.localScale.y - y);
		tr.position = position;
	}
}
