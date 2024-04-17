using UnityEngine;

public class LoseScript : MonoBehaviour
{
	public Transform player;

	public PlayerScript view;

	public bool onthistime;

	public int timeleft;

	public Light l1;

	public Light l2;

	public AudioSource san1;

	public AudioSource san2;

	public AudioSource san3;

	public Camera original;

	public GUIStyle credits;

	public bool quitted;

	public Light sun;

	public Material daysky;

	public Material nightsky;

	public Vector3 oldposition;

	public int mhdelay;

	private void Start()
	{
		nightsky = RenderSettings.skybox;
		base.transform.parent.GetComponent<Camera>().enabled = false;
		Color color = base.GetComponent<Renderer>().material.color;
		color.a = 0.4f;
		base.GetComponent<Renderer>().material.color = color;
	}

	private void OnGUI()
	{
		if (view.pages >= 8)
		{
			if (view.mh)
			{
				if (timeleft >= 1100 && timeleft < 1350)
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "The tape ends there.", credits);
				}
				else if (timeleft >= 1500 && timeleft < 1900)
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 65, 600f, 50f), "There was no sign of who had", credits);
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "filmed it, only a label on the", credits);
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 15, 600f, 50f), "tape which read 'WATCH THIS'.", credits);
				}
				else if (timeleft >= 2050 && timeleft < 2300)
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "Someone is trying to help me.", credits);
				}
			}
			if (timeleft >= 1050 + mhdelay && timeleft < 1300 + mhdelay)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 600f, 50f), "Game Design & Programming", credits);
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "Mark J. Hadley", credits);
			}
			else if (timeleft >= 1400 + mhdelay && timeleft < 1650 + mhdelay)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 600f, 50f), "Music & Sound", credits);
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "Mark J. Hadley", credits);
			}
			else if (timeleft >= 1750 + mhdelay && timeleft < 2250 + mhdelay)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 600f, 50f), "Models", credits);
				if (timeleft < 1850 + mhdelay)
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "Pau Cano", credits);
				}
				else if (timeleft < 1950 + mhdelay)
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "Universal Image", credits);
				}
				else if (timeleft < 2050 + mhdelay)
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "VIS Games", credits);
				}
				else if (timeleft < 2150 + mhdelay)
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "Profi Developers", credits);
				}
				else
				{
					GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "Unity Technology", credits);
				}
			}
			else if (timeleft >= 2350 + mhdelay && timeleft < 2600 + mhdelay)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "Thanks for playing", credits);
			}
			return;
		}
		if (view.mh)
		{
			if (timeleft >= 300 && timeleft < 550)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "The tape ends there.", credits);
			}
			else if (timeleft >= 700 && timeleft < 1100)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 65, 600f, 50f), "There was no label on the", credits);
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "tape, nor any indication", credits);
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 15, 600f, 50f), "as to who had filmed it.", credits);
			}
			else if (timeleft >= 1250 && timeleft < 1500)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "But I intend to find out.", credits);
			}
		}
		if (timeleft >= 250 + mhdelay && !quitted)
		{
			GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 600f, 50f), "Pages: " + view.pages + "/8", credits);
			GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "Click to continue", credits);
		}
	}

	private void Update()
	{
		if (view.pages < 8 && timeleft >= 250 && Input.GetMouseButtonDown(0))
		{
			quitted = true;
			Application.LoadLevel(0);
		}
	}

	private void FixedUpdate()
	{
		base.transform.parent.position = new Vector3(0f, -180f, 0f);
		if (view.startgame.timer == 1599 && view.daytime)
		{
			RenderSettings.skybox = daysky;
		}
		if (!view.lost)
		{
			return;
		}
		if (timeleft == 0)
		{
			original.enabled = false;
			base.transform.parent.GetComponent<Camera>().enabled = true;
			oldposition = player.position;
			player.position = new Vector3(0f, -2000f, 0f);
			RenderSettings.ambientLight = Color.black;
			sun.enabled = false;
			if (view.mh)
			{
				mhdelay = 1400;
			}
			view.dust.Stop();
		}
		base.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Random.value, Random.value);
		if (timeleft < 20 || timeleft > 120)
		{
			onthistime = false;
		}
		else if ((double)Random.value < 0.7)
		{
			onthistime = true;
		}
		else
		{
			onthistime = false;
		}
		if (onthistime)
		{
			l1.intensity = 1f;
			l2.intensity = 1f;
			san1.volume = 1f;
			san2.volume = 1f;
			san3.volume = 1f;
		}
		else if (timeleft < 250)
		{
			l1.intensity = 0f;
			l2.intensity = 0f;
			san1.volume = 0f;
			san2.volume = 0f;
			san3.volume = 0f;
		}
		if (timeleft < 250 + mhdelay || (timeleft < 2700 + mhdelay && view.pages >= 8))
		{
			timeleft++;
		}
		if (timeleft == 250)
		{
			san1.volume = 0f;
			san2.volume = 0f;
			san3.volume = 0f;
		}
		if (timeleft == 251 && view.pages >= 8)
		{
			onthistime = false;
			if (view.daytime)
			{
				RenderSettings.skybox = nightsky;
				RenderSettings.ambientLight = Color.black;
				view.torch.enabled = true;
				sun.enabled = false;
			}
			else
			{
				RenderSettings.skybox = daysky;
				RenderSettings.ambientLight = Color.gray;
				sun.enabled = true;
				if (!view.mh)
				{
					PlayerPrefs.SetInt("daytime", 1);
				}
			}
			if (view.dustyair && view.daytime)
			{
				view.dust.Play();
			}
			original.enabled = true;
			base.transform.parent.GetComponent<Camera>().enabled = false;
			player.position = oldposition;
			player.LookAt(new Vector3(view.endfix.position.x, player.position.y, view.endfix.position.z));
		}
		if (timeleft >= 950 && view.pages >= 8)
		{
			original.enabled = false;
			base.transform.parent.GetComponent<Camera>().enabled = true;
			l1.intensity = 0f;
			l2.intensity = 0f;
			sun.enabled = false;
			RenderSettings.ambientLight = Color.black;
			player.position = new Vector3(0f, -2000f, 0f);
		}
		if (timeleft > 250 && view.pages >= 8)
		{
			if (view.mh)
			{
				if ((float)timeleft < 425f)
				{
					san1.volume = (450f - (float)timeleft) / 100f;
					san2.volume = (350f - (float)timeleft) / 100f;
					san3.volume = 0f;
				}
				else if (timeleft < 950)
				{
					san1.volume = 0.25f;
					san2.volume = 0f;
					san3.volume = 0f;
				}
				else
				{
					san1.volume = 0f;
					san2.volume = 0f;
					san3.volume = 0f;
				}
			}
			else
			{
				san1.volume = (450f - (float)timeleft) / 100f;
				san2.volume = (350f - (float)timeleft) / 100f;
				san3.volume = 0f;
			}
		}
		if (timeleft >= 2700 + mhdelay && view.pages >= 8)
		{
			quitted = true;
			Application.LoadLevel(0);
		}
		if (timeleft == 250 + mhdelay && view.pages >= 8)
		{
			view.fadeinmusic = 0f;
		}
		if (timeleft == 2500 + mhdelay && view.pages >= 8)
		{
			view.fadeinmusic = 0f;
		}
	}
}
