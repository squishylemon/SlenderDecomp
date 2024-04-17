using UnityEngine;

public class StaticScript : MonoBehaviour
{
	public PlayerScript view;

	public LoseScript final;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		Color color = base.renderer.material.color;
		if (!view.lost)
		{
			if (view.flicker <= 0)
			{
				color.a = 0.25f - view.sanity / 400f;
			}
			else
			{
				color.a = 1f;
			}
		}
		else if (final.timeleft >= 250)
		{
			color.a = (450f - (float)final.timeleft) / 200f;
		}
		else
		{
			color.a = 0f;
		}
		base.renderer.material.color = color;
		base.renderer.material.mainTextureOffset = new Vector2(Random.value, Random.value);
	}
}
