using UnityEngine;

public class AmbientScript : MonoBehaviour
{
	public Transform rotateme;

	public int timer = 100;

	public AudioClip fs1;

	public AudioClip fs2;

	public AudioClip fs3;

	public AudioClip fs4;

	public AudioClip fs5;

	public AudioClip fs6;

	public AudioClip fs7;

	public AudioClip fs8;

	public AudioClip fs9;

	public AudioClip fs10;

	public AudioClip fs11;

	public PlayerScript view;

	public AudioSource wind;

	public IntroScript intro;

	public LoseScript loser;

	private void Start()
	{
		rotateme.Rotate(new Vector3(0f, Random.value * 360f, 0f));
	}

	private void Update()
	{
		if ((intro.gamestarted && loser.timeleft == 0 && (!view.mh || (intro.timer >= 1600 && view.mh))) || (loser.timeleft > 250 && loser.timeleft < 900 && view.pages >= 8))
		{
			wind.volume = 1f;
			timer--;
			if (timer > 0)
			{
				return;
			}
			int num = 0;
			timer = (int)(Random.value * 500f) + 100;
			switch ((intro.timer >= 1700) ? ((int)(Random.value * 9f) + 1) : ((int)(Random.value * 8f) + 1))
			{
			case 1:
			case 2:
				if ((!view.lost && !view.daytime) || (view.lost && view.daytime))
				{
					AudioSource.PlayClipAtPoint(fs1, base.transform.position, 1f);
				}
				else
				{
					AudioSource.PlayClipAtPoint(fs8, base.transform.position, 1f);
				}
				break;
			case 3:
			case 4:
				if ((!view.lost && !view.daytime) || (view.lost && view.daytime))
				{
					AudioSource.PlayClipAtPoint(fs2, base.transform.position, 1f);
				}
				else
				{
					AudioSource.PlayClipAtPoint(fs9, base.transform.position, 1f);
				}
				break;
			case 5:
			case 6:
				if ((!view.lost && !view.daytime) || (view.lost && view.daytime))
				{
					AudioSource.PlayClipAtPoint(fs3, base.transform.position, 1f);
				}
				else
				{
					AudioSource.PlayClipAtPoint(fs10, base.transform.position, 1f);
				}
				break;
			case 7:
			case 8:
				if ((!view.lost && !view.daytime) || (view.lost && view.daytime))
				{
					AudioSource.PlayClipAtPoint(fs4, base.transform.position, 1f);
				}
				else
				{
					AudioSource.PlayClipAtPoint(fs11, base.transform.position, 1f);
				}
				break;
			case 9:
				switch ((int)(Random.value * 3f))
				{
				case 0:
					AudioSource.PlayClipAtPoint(fs5, base.transform.position, 1f);
					break;
				case 1:
					AudioSource.PlayClipAtPoint(fs6, base.transform.position, 1f);
					break;
				case 2:
					AudioSource.PlayClipAtPoint(fs7, base.transform.position, 1f);
					break;
				}
				break;
			}
			rotateme.Rotate(new Vector3(0f, Random.value * 360f, 0f));
		}
		else
		{
			wind.volume = 0f;
		}
	}
}
