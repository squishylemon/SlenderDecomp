using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public bool debug;

	public int pages;

	public int level;

	public int toolong = 12000;

	public float sanity = 100f;

	public float stamina = 100f;

	public float maxstam = 100f;

	public int scared;

	public bool cansee;

	public bool justsaw;

	public float drain;

	public bool lost;

	public bool caught;

	public float maxrange = 100f;

	public float minrange = 80f;

	public float fadeinmusic = 2f;

	public AudioSource san1;

	public AudioSource san2;

	public AudioSource san3;

	public AudioSource music1;

	public AudioSource music2;

	public AudioSource music3;

	public AudioSource music4;

	public AudioSource breathing;

	public AudioClip s1;

	public AudioClip s2;

	public AudioClip s3;

	public AudioClip s4;

	public AudioClip s5;

	public AudioClip s6;

	public AudioClip s7;

	public AudioClip s8;

	public AudioClip s9;

	public AudioClip s10;

	public AudioClip s11;

	public AudioClip s12;

	public AudioClip t1;

	public AudioClip t2;

	public AudioClip t3;

	public AudioClip t4;

	public AudioClip t5;

	public AudioClip t6;

	public AudioClip t7;

	public AudioSource climbfence;

	public AudioSource flashlight;

	public Light torch;

	public Light eyes;

	public float battery = 1f;

	public bool torchdying;

	public bool flraised = true;

	public Transform flup;

	public Transform fldown;

	public int laststep;

	public int stepcd = 120;

	public GameObject SM;

	public GUIStyle hint;

	public int fadeoutgui = 400;

	public MouseLook ml1;

	public MouseLook ml2;

	public CharacterMotor cm;

	public int flicker;

	public bool endflicker;

	public bool lastflicker;

	public float zoom = 60f;

	public Transform statscale;

	public AudioSource zsound;

	public LoseScript endgame;

	public IntroScript startgame;

	public int finaldelay;

	public Transform chasetest;

	public Transform tentacles;

	public bool daytime;

	public bool mh;

	public Transform nearpage;

	public Transform endfix;

	public ParticleSystem dust;

	public bool dustyair = true;

	public bool backedup;

	public int sprintcooldown;

	public SprintScript sprscr;

	public bool paused;

	public float targetfog = 0.02f;

	public bool amrunning;

	public bool cranking;

	public AudioSource cranksound;

	public LayerMask mask;

	private void Start()
	{
		cm.canControl = false;
		ml1.enabled = false;
		ml2.enabled = false;
	}

	private void OnGUI()
	{
		if (paused)
		{
			GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 600f, 50f), "PAUSED", hint);
			GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "ESC to resume", hint);
			GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 25, 600f, 50f), "SPACE to quit", hint);
		}
		else if (fadeoutgui < 400 && !mh)
		{
			if (pages == 0)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "Collect all 8 pages", hint);
			}
			else
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "Pages " + pages + "/8", hint);
			}
		}
	}

	private void Update()
	{
		if (!paused)
		{
			if (debug)
			{
				if (Input.GetKeyDown("f1"))
				{
					pages = 7;
					maxrange = 30f;
					minrange = 10f;
					targetfog = 0.1f;
					RenderSettings.fogDensity = 0.1f;
				}
				if (Input.GetKeyDown("f2"))
				{
					base.transform.parent.transform.position = new Vector3(0f, 2f, 0f);
				}
				if (Input.GetKeyDown("f3"))
				{
					pages = 8;
					lost = true;
				}
				if (Input.GetKeyDown("f4"))
				{
					toolong = 60;
				}
			}
			if (Input.GetMouseButtonDown(0) && startgame.timer < 1598 && startgame.timer > 0)
			{
				startgame.timer = 1598;
				climbfence.Stop();
			}
			if (Input.GetKeyDown("escape"))
			{
				if (startgame.gamestarted)
				{
					if (startgame.timer < 1598)
					{
						startgame.timer = 1598;
						climbfence.Stop();
					}
					else if (!lost && sanity == 100f)
					{
						paused = true;
						Time.timeScale = 0f;
						cm.canControl = false;
						ml1.enabled = false;
						ml2.enabled = false;
					}
					else if (!lost)
					{
						flicker = 3;
					}
				}
				else if (!startgame.gamestarted)
				{
					backedup = true;
				}
			}
			if (startgame.fltype == 0)
			{
				if ((Input.GetMouseButtonDown(1) || Input.GetButtonDown("Flashlight")) && startgame.timer >= 1600 && ((!lost && !daytime) || (endgame.timeleft > 250 && endgame.timeleft < 950 && daytime)))
				{
					if (torch.enabled)
					{
						torch.enabled = false;
					}
					else if (battery > 0f)
					{
						torch.enabled = true;
					}
					flashlight.Play();
				}
			}
			else if (startgame.fltype == 2)
			{
				if ((Input.GetMouseButton(1) || Input.GetButton("Flashlight")) && startgame.timer >= 1600 && ((!lost && !daytime) || (endgame.timeleft > 250 && endgame.timeleft < 950 && daytime)) && !Input.GetButton("Jog/Sprint") && stamina >= 10f)
				{
					cranking = true;
					cranksound.volume = 1f;
				}
				else
				{
					cranking = false;
					cranksound.volume = 0f;
				}
			}
			if (startgame.gamestarted)
			{
				Screen.lockCursor = true;
			}
		}
		else if (Input.GetKeyDown("escape"))
		{
			paused = false;
			Time.timeScale = 1f;
			cm.canControl = true;
			ml1.enabled = true;
			ml2.enabled = true;
		}
		else if (Input.GetKeyDown("space"))
		{
			Time.timeScale = 1f;
			cm.canControl = true;
			ml1.enabled = true;
			ml2.enabled = true;
			Application.LoadLevel(0);
		}
		if (endflicker)
		{
			endflicker = false;
			lastflicker = true;
		}
	}

	private void FixedUpdate()
	{
		if (paused)
		{
			return;
		}
		chasetest.position = base.transform.position;
		Quaternion rotation = Quaternion.LookRotation(base.transform.position - SM.transform.position, Vector3.up);
		rotation.x = 0f;
		rotation.z = 0f;
		chasetest.rotation = rotation;
		if (fadeoutgui < 400)
		{
			fadeoutgui++;
		}
		if ((double)targetfog + 0.001 < (double)RenderSettings.fogDensity)
		{
			RenderSettings.fogDensity -= 0.001f;
		}
		else if ((double)targetfog - 0.0002 > (double)RenderSettings.fogDensity)
		{
			RenderSettings.fogDensity += 0.0002f;
		}
		else
		{
			RenderSettings.fogDensity = targetfog;
		}
		if (toolong > 0 && startgame.timer >= 1600 && pages < 8)
		{
			toolong--;
			if (toolong <= 0)
			{
				toolong = 12000;
				if (pages + level < 9)
				{
					level++;
					maxrange = 100 - (pages + level) * 11;
					minrange = 80 - (pages + level) * 10;
					if (pages + level == 1 || pages + level == 3 || pages + level == 5 || pages + level == 7)
					{
						fadeinmusic = 0f;
					}
				}
			}
		}
		if (startgame.timer >= 1600)
		{
			if (!torch.enabled && eyes.range < 120f)
			{
				eyes.range += 0.15f;
				if (eyes.range >= 120f)
				{
					eyes.range = 120f;
				}
			}
			else if (torch.enabled)
			{
				if (startgame.fltype == 0)
				{
					battery -= 1.8E-05f;
				}
				else if (startgame.fltype == 2 && !cranking)
				{
					battery -= 0.0002f;
				}
				if (battery <= 0.15f)
				{
					battery = 0f;
					torch.enabled = false;
				}
				if (eyes.range > 30f)
				{
					eyes.range -= 0.5f;
					if (eyes.range <= 30f)
					{
						eyes.range = 30f;
					}
				}
			}
			if (battery < 0.25f && Random.value < 0.2f)
			{
				if (torchdying)
				{
					torchdying = false;
				}
				else
				{
					torchdying = true;
				}
			}
			if (torchdying)
			{
				torch.intensity = battery - 0.015f;
			}
			else
			{
				torch.intensity = battery;
			}
		}
		if (pages >= 8)
		{
			dust.startColor = new Color(0.5f, 0.5f, 0.5f, 0.125f);
		}
		else
		{
			dust.startColor = new Color(0.5f, 0.5f, 0.5f, 0.0625f + (float)(pages + level) * 0.045f);
		}
		if (caught && !lost)
		{
			ml1.enabled = false;
			cm.canControl = false;
			Vector3 vector = new Vector3(SM.transform.position.x, SM.transform.position.y + 1f, SM.transform.position.z);
			Quaternion to = Quaternion.LookRotation(vector - base.transform.parent.transform.position);
			base.transform.parent.transform.rotation = Quaternion.Slerp(base.transform.parent.transform.rotation, to, Time.deltaTime * 2f);
		}
		if (!lost || endgame.timeleft > 250)
		{
			if (startgame.timer >= 1600)
			{
				if (caught)
				{
					sanity -= 1f;
					if (sanity < 0f)
					{
						lost = true;
					}
				}
				if (!cansee && !caught)
				{
					if (sanity <= 100f)
					{
						sanity += 0.1f;
						if (sanity > 100f)
						{
							sanity = 100f;
						}
					}
				}
				else if (drain > 0f)
				{
					if (!caught)
					{
						sanity -= drain;
					}
					if (sanity < 0f && !lost)
					{
						lost = true;
					}
				}
				if (lost)
				{
					sanity = 100f;
				}
				if (sanity < 0f)
				{
					sanity = 0f;
				}
				justsaw = cansee;
				if (endgame.timeleft == 0)
				{
					if (sanity < 70f || mh)
					{
						san1.volume = 1f;
						if (sanity < 40f)
						{
							san2.volume = 1f;
							if (sanity < 10f)
							{
								san3.volume = 1f;
							}
							else
							{
								san3.volume = (40f - sanity) / 30f;
							}
						}
						else
						{
							san2.volume = (70f - sanity) / 30f;
							san3.volume = 0f;
						}
					}
					else
					{
						san1.volume = (100f - sanity) / 30f;
						san2.volume = 0f;
						san3.volume = 0f;
					}
				}
				else if (endgame.timeleft == 0)
				{
					san1.volume = 0f;
					san2.volume = 0f;
					san3.volume = 0f;
				}
				if (flicker > 0 || endflicker || lastflicker)
				{
					san1.volume = 1f;
					san2.volume = 1f;
					san3.volume = 1f;
					flicker--;
					if (flicker == 0 && !lastflicker)
					{
						endflicker = true;
					}
					if (lastflicker)
					{
						lastflicker = false;
					}
				}
				if (sanity > 80f || mh)
				{
					tentacles.localScale = new Vector3(0f, 0f, 0f);
				}
				else
				{
					tentacles.localScale = new Vector3((80f - sanity) * 0.01f, (80f - sanity) * 0.01f, (80f - sanity) * (1f / 160f));
				}
				if (lost && !mh)
				{
					tentacles.localScale = new Vector3(0.8f, 0.8f, 0.5f);
				}
				if (pages + level > 0 && endgame.timeleft == 0 && !mh)
				{
					if (pages + level < 3)
					{
						music1.volume = fadeinmusic;
					}
					else if (pages + level < 5)
					{
						music1.volume = 2f - fadeinmusic;
						music2.volume = fadeinmusic;
					}
					else if (pages + level < 7)
					{
						music1.volume = 0f;
						music2.volume = 2f - fadeinmusic;
						music3.volume = fadeinmusic;
					}
					else if (pages + level < 8)
					{
						music1.volume = 0f;
						music2.volume = 0f;
						music3.volume = 2f - fadeinmusic;
						music4.volume = fadeinmusic;
					}
					else
					{
						music1.volume = 0f;
						music2.volume = 0f;
						music3.volume = 0f;
						music4.volume = 1f - fadeinmusic / 2f;
					}
					fadeinmusic += 0.01f;
					if (fadeinmusic > 2f)
					{
						fadeinmusic = 2f;
					}
				}
				if (scared > 0)
				{
					scared--;
				}
				if (Input.GetButton("Jog/Sprint") && Input.GetAxis("Vertical") > 0f)
				{
					if (!amrunning && stamina >= 10f)
					{
						amrunning = true;
						stamina -= 5f;
					}
					if (flraised)
					{
						flraised = false;
					}
					Quaternion to2 = Quaternion.LookRotation(fldown.position - torch.transform.position);
					torch.transform.rotation = Quaternion.Slerp(torch.transform.rotation, to2, Time.deltaTime * 8f);
					if (scared > 0)
					{
						stamina -= 0.1125f;
						if (stamina < 10f)
						{
							stamina = 0f;
							stepcd -= 4;
						}
						else
						{
							stepcd -= 6;
							maxstam -= 0.009f;
							if (maxstam <= 45f)
							{
								maxstam = 45f;
							}
						}
					}
					else
					{
						stamina -= sprscr.jogSpeed / 105f;
						if (stamina < 10f)
						{
							stamina = 0f;
							stepcd -= 4;
						}
						else
						{
							stepcd -= 5;
						}
					}
				}
				else
				{
					amrunning = false;
					if (sprintcooldown > 0)
					{
						sprintcooldown--;
					}
					if (!flraised)
					{
						flraised = true;
						sprintcooldown = 60;
					}
					if (cranking)
					{
						Quaternion to2 = Quaternion.LookRotation(fldown.position - torch.transform.position);
						torch.transform.rotation = Quaternion.Slerp(torch.transform.rotation, to2, Time.deltaTime * 8f);
						if (battery < 0.15f)
						{
							battery = 0.151f;
							torch.enabled = true;
						}
						battery += 0.001f;
						if (battery > 1f)
						{
							battery = 1f;
						}
						stamina -= 0.025f;
						if (stamina < 10f)
						{
							stamina = 0f;
						}
					}
					else
					{
						RaycastHit hitInfo;
						Quaternion to2 = ((nearpage == null) ? Quaternion.LookRotation(flup.position - torch.transform.position) : ((!Physics.Raycast(base.transform.position, (nearpage.position - base.transform.position).normalized, out hitInfo, 2f, mask)) ? Quaternion.LookRotation(flup.position - torch.transform.position) : ((!(hitInfo.collider.gameObject == nearpage.gameObject)) ? Quaternion.LookRotation(flup.position - torch.transform.position) : Quaternion.LookRotation(nearpage.position - torch.transform.position))));
						if (sprintcooldown <= 0)
						{
							torch.transform.rotation = Quaternion.Slerp(torch.transform.rotation, to2, Time.deltaTime * 8f);
						}
						else
						{
							torch.transform.rotation = Quaternion.Slerp(torch.transform.rotation, to2, Time.deltaTime * (2f + (60f - (float)sprintcooldown) / 10f));
						}
						if (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f)
						{
							stamina += 0.05f;
						}
						else
						{
							stamina += 0.1f;
						}
						if (stamina > maxstam)
						{
							stamina = maxstam;
						}
					}
					if (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f)
					{
						stepcd -= 4;
					}
					else
					{
						stepcd = 120;
					}
				}
				if (Input.GetButton("Zoom In") && !Input.GetButton("Zoom Out") && zoom > 20f)
				{
					zoom -= 0.75f;
					if (zoom < 20f)
					{
						zoom = 20f;
					}
					zsound.volume = 1f;
				}
				else if (Input.GetButton("Zoom Out") && !Input.GetButton("Zoom In") && zoom < 60f)
				{
					zoom += 0.75f;
					if (zoom > 60f)
					{
						zoom = 60f;
					}
					zsound.volume = 1f;
				}
				else
				{
					zsound.volume = 0f;
				}
				base.GetComponent<Camera>().fieldOfView = zoom;
				statscale.localScale = new Vector3((zoom - 2.5f) / 57.5f, (zoom - 2.5f) / 57.5f, (zoom - 2.5f) / 57.5f);
				if (stamina < 30f)
				{
					breathing.volume = (30f - stamina) / 20f;
				}
				else
				{
					breathing.volume = 0f;
				}
				if (stepcd <= 0 && endgame.timeleft < 950)
				{
					stepcd = 120;
					int num = 0;
					if (base.transform.parent.transform.position.y <= 2.051f)
					{
						do
						{
							num = (int)(Random.value * 12f) + 1;
						}
						while (num == laststep);
						switch (num)
						{
						case 1:
							AudioSource.PlayClipAtPoint(s1, base.transform.position);
							break;
						case 2:
							AudioSource.PlayClipAtPoint(s2, base.transform.position);
							break;
						case 3:
							AudioSource.PlayClipAtPoint(s3, base.transform.position);
							break;
						case 4:
							AudioSource.PlayClipAtPoint(s4, base.transform.position);
							break;
						case 5:
							AudioSource.PlayClipAtPoint(s5, base.transform.position);
							break;
						case 6:
							AudioSource.PlayClipAtPoint(s6, base.transform.position);
							break;
						case 7:
							AudioSource.PlayClipAtPoint(s7, base.transform.position);
							break;
						case 8:
							AudioSource.PlayClipAtPoint(s8, base.transform.position);
							break;
						case 9:
							AudioSource.PlayClipAtPoint(s9, base.transform.position);
							break;
						case 10:
							AudioSource.PlayClipAtPoint(s10, base.transform.position);
							break;
						case 11:
							AudioSource.PlayClipAtPoint(s11, base.transform.position);
							break;
						case 12:
							AudioSource.PlayClipAtPoint(s12, base.transform.position);
							break;
						}
					}
					else
					{
						do
						{
							num = (int)(Random.value * 7f) + 1;
						}
						while (num == laststep);
						switch (num)
						{
						case 1:
							AudioSource.PlayClipAtPoint(t1, base.transform.position, 0.5f);
							break;
						case 2:
							AudioSource.PlayClipAtPoint(t2, base.transform.position, 0.5f);
							break;
						case 3:
							AudioSource.PlayClipAtPoint(t3, base.transform.position, 0.5f);
							break;
						case 4:
							AudioSource.PlayClipAtPoint(t4, base.transform.position, 0.5f);
							break;
						case 5:
							AudioSource.PlayClipAtPoint(t5, base.transform.position, 0.5f);
							break;
						case 6:
							AudioSource.PlayClipAtPoint(t6, base.transform.position, 0.5f);
							break;
						case 7:
							AudioSource.PlayClipAtPoint(t7, base.transform.position, 0.5f);
							break;
						}
					}
					laststep = num;
				}
			}
			else if (startgame.timer < 900 && startgame.timer > 0 && !mh)
			{
				if (startgame.skintro)
				{
					startgame.timer = 1598;
				}
				else
				{
					stepcd -= 4;
					if (stepcd <= 0)
					{
						stepcd = 120;
						int num2 = 0;
						do
						{
							num2 = (int)(Random.value * 12f) + 1;
						}
						while (num2 == laststep);
						switch (num2)
						{
						case 1:
							AudioSource.PlayClipAtPoint(s1, base.transform.position);
							break;
						case 2:
							AudioSource.PlayClipAtPoint(s2, base.transform.position);
							break;
						case 3:
							AudioSource.PlayClipAtPoint(s3, base.transform.position);
							break;
						case 4:
							AudioSource.PlayClipAtPoint(s4, base.transform.position);
							break;
						case 5:
							AudioSource.PlayClipAtPoint(s5, base.transform.position);
							break;
						case 6:
							AudioSource.PlayClipAtPoint(s6, base.transform.position);
							break;
						case 7:
							AudioSource.PlayClipAtPoint(s7, base.transform.position);
							break;
						case 8:
							AudioSource.PlayClipAtPoint(s8, base.transform.position);
							break;
						case 9:
							AudioSource.PlayClipAtPoint(s9, base.transform.position);
							break;
						case 10:
							AudioSource.PlayClipAtPoint(s10, base.transform.position);
							break;
						case 11:
							AudioSource.PlayClipAtPoint(s11, base.transform.position);
							break;
						case 12:
							AudioSource.PlayClipAtPoint(s12, base.transform.position);
							break;
						}
						laststep = num2;
					}
				}
			}
			else if (startgame.timer == 950)
			{
				stepcd = 120;
				if (!mh)
				{
					climbfence.Play();
				}
			}
			else if (startgame.timer == 1599)
			{
				cm.canControl = true;
				ml1.enabled = true;
				ml2.enabled = true;
				if (daytime)
				{
					torch.enabled = false;
				}
			}
		}
		if (!lost)
		{
			return;
		}
		music1.volume = 0f;
		music2.volume = 0f;
		music3.volume = 0f;
		music4.volume = 0f;
		if (endgame.timeleft < 250)
		{
			breathing.volume = 0f;
			zsound.volume = 0f;
			torch.enabled = false;
			return;
		}
		if (endgame.timeleft >= 250)
		{
			cm.canControl = true;
			ml1.enabled = true;
			ml2.enabled = true;
		}
		if (endgame.timeleft >= 950)
		{
			breathing.volume = 0f;
			zsound.volume = 0f;
			cm.canControl = false;
			ml1.enabled = false;
			ml2.enabled = false;
		}
		if (pages < 8 || endgame.timeleft < 1000 + endgame.mhdelay)
		{
			return;
		}
		if (endgame.timeleft < 2500 + endgame.mhdelay)
		{
			music1.volume = fadeinmusic;
			fadeinmusic += 0.01f;
			if (fadeinmusic > 2f)
			{
				fadeinmusic = 2f;
			}
		}
		else
		{
			music1.volume = 1f - fadeinmusic / 2f;
			fadeinmusic += 0.01f;
			if (fadeinmusic > 2f)
			{
				fadeinmusic = 2f;
			}
		}
	}
}
