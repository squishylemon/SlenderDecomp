using UnityEngine;

public class IntroScript : MonoBehaviour
{
	public int timer;

	public GUIStyle credits;

	public Camera mainview;

	public Transform spotlight;

	public PlayerScript view;

	public AudioSource flashlight;

	public Light sun;

	public bool gamestarted;

	public bool optmenu;

	public bool extmenu;

	public MouseLook mlx;

	public MouseLook mly;

	public GUISkin menu;

	public Texture2D logoTexture;

	public bool sunup;

	public int entry;

	public Terrain land;

	public GameObject stat1;

	public GameObject stat2;

	public bool modeoff = true;

	public bool skintro;

	public ParticleSystem sk1;

	public ParticleSystem sk2;

	public ParticleSystem sk3;

	public ParticleSystem sk4;

	public ParticleSystem sk5;

	public ParticleSystem sk6;

	public ParticleSystem sk7;

	public ParticleSystem sk8;

	public Transform toptitle;

	public AudioSource thememusic;

	public Light flsource;

	public int fltype;

	public bool mythosmenu;

	public bool youtubemenu;

	public bool infomenu;

	private void Start()
	{
		sk1.enableEmission = true;
		sk2.enableEmission = true;
		sk3.enableEmission = true;
		sk4.enableEmission = true;
		sk5.enableEmission = true;
		sk6.enableEmission = true;
		sk7.enableEmission = true;
		sk8.enableEmission = true;
		Screen.lockCursor = false;
		view.fadeoutgui = 400;
		mainview.enabled = false;
		base.GetComponent<Camera>().enabled = true;
		if (PlayerPrefs.HasKey("minvert"))
		{
			if (PlayerPrefs.GetInt("minvert") == 1)
			{
				mly.inverted = true;
			}
		}
		else
		{
			PlayerPrefs.SetInt("minvert", 0);
		}
		if (PlayerPrefs.HasKey("daytime"))
		{
			if (PlayerPrefs.GetInt("daytime") == 1)
			{
				sunup = true;
			}
		}
		else
		{
			PlayerPrefs.SetInt("daytime", 0);
		}
		if (PlayerPrefs.HasKey("trees"))
		{
			if (PlayerPrefs.GetFloat("trees") < 20f)
			{
				PlayerPrefs.SetFloat("trees", 80f);
				land.treeBillboardDistance = 80f;
				land.treeMaximumFullLODCount = 160;
			}
			else
			{
				land.treeBillboardDistance = PlayerPrefs.GetFloat("trees");
				land.treeMaximumFullLODCount = (int)(PlayerPrefs.GetFloat("trees") * 2f);
			}
		}
		else
		{
			PlayerPrefs.SetFloat("trees", 80f);
			land.treeBillboardDistance = 80f;
			land.treeMaximumFullLODCount = 160;
		}
		if (PlayerPrefs.HasKey("dusty"))
		{
			if (PlayerPrefs.GetInt("dusty") == 1)
			{
				view.dustyair = true;
			}
			else
			{
				view.dustyair = false;
			}
		}
		else
		{
			PlayerPrefs.SetInt("dusty", 1);
			view.dustyair = true;
		}
		if (PlayerPrefs.HasKey("msensitivity"))
		{
			mlx.sensitivityX = PlayerPrefs.GetFloat("msensitivity");
			mly.sensitivityY = PlayerPrefs.GetFloat("msensitivity");
		}
		else
		{
			PlayerPrefs.SetFloat("msensitivity", 5f);
			mlx.sensitivityX = 5f;
			mlx.sensitivityY = 5f;
		}
		if (PlayerPrefs.HasKey("skintro"))
		{
			if (PlayerPrefs.GetInt("skintro") == 1)
			{
				skintro = true;
			}
			else
			{
				skintro = false;
			}
		}
		else
		{
			PlayerPrefs.SetInt("skintro", 0);
			skintro = false;
		}
		if (PlayerPrefs.HasKey("grasslevel"))
		{
			land.detailObjectDensity = PlayerPrefs.GetFloat("grasslevel");
		}
		else
		{
			PlayerPrefs.SetFloat("grasslevel", 1f);
			land.detailObjectDensity = 1f;
		}
		if (PlayerPrefs.HasKey("currentm"))
		{
			if (PlayerPrefs.GetInt("currentm") == 1 && PlayerPrefs.GetInt("daytime") == 1)
			{
				modeoff = false;
				view.mh = true;
				view.daytime = false;
			}
			else if (PlayerPrefs.GetInt("currentm") == 2 && PlayerPrefs.GetInt("daytime") == 1)
			{
				modeoff = false;
				view.mh = false;
				view.daytime = true;
			}
			else if (PlayerPrefs.GetInt("currentm") == 3)
			{
				modeoff = false;
				view.mh = true;
				view.daytime = false;
				PlayerPrefs.SetInt("currentm", 0);
			}
			else
			{
				modeoff = true;
				view.mh = false;
				view.daytime = false;
			}
		}
		else
		{
			PlayerPrefs.SetInt("currentm", 0);
			modeoff = true;
			view.mh = false;
			view.daytime = false;
		}
		if (PlayerPrefs.HasKey("fltype"))
		{
			if (PlayerPrefs.GetInt("daytime") == 1)
			{
				switch (PlayerPrefs.GetInt("fltype"))
				{
				case 0:
					fltype = 0;
					break;
				case 1:
					fltype = 1;
					break;
				case 2:
					fltype = 2;
					break;
				}
			}
		}
		else
		{
			PlayerPrefs.SetInt("fltype", 0);
		}
	}

	private void OnGUI()
	{
		if (view.mh)
		{
			if (timer >= 300 && timer < 500)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "Entry #" + entry, credits);
			}
			else if (timer >= 650 && timer < 1000)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 45, 600f, 50f), "I found the following tape", credits);
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 5, 600f, 50f), "when I returned to the woods.", credits);
			}
			else if (timer >= 1150 && timer < 1500)
			{
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 45, 600f, 50f), "The video quality was poor, and I", credits);
				GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 5, 600f, 50f), "don't know when it was filmed.", credits);
			}
		}
		else if (timer >= 50 && timer < 400)
		{
			GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "Parsec Productions", credits);
		}
		else if (timer >= 500 && timer < 850)
		{
			GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 25, 600f, 50f), "Presents", credits);
		}
		if (gamestarted)
		{
			return;
		}
		GUI.skin = menu;
		GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 600f, 300f));
		GUI.Box(new Rect(150f, 35f, 300f, 300f), string.Empty);
		if (!optmenu && !extmenu && !mythosmenu)
		{
			if (GUI.Button(new Rect(210f, 50f, 180f, 40f), "Start game"))
			{
				view.flashlight.Play();
				gamestarted = true;
				Screen.lockCursor = false;
				entry = Random.Range(4, 16);
				if (view.mh)
				{
					timer = 200;
				}
				else
				{
					stat1.GetComponent<Renderer>().enabled = false;
					stat2.GetComponent<Renderer>().enabled = false;
				}
				if (view.dustyair && !view.daytime)
				{
					view.dust.Play();
				}
				sk1.enableEmission = false;
				sk1.Clear();
				sk2.enableEmission = false;
				sk2.Clear();
				sk3.enableEmission = false;
				sk3.Clear();
				sk4.enableEmission = false;
				sk4.Clear();
				sk5.enableEmission = false;
				sk5.Clear();
				sk6.enableEmission = false;
				sk6.Clear();
				sk7.enableEmission = false;
				sk7.Clear();
				sk8.enableEmission = false;
				sk8.Clear();
				toptitle.transform.Rotate(new Vector3(180f, 0f, 0f));
				thememusic.Stop();
				switch (fltype)
				{
				case 1:
					flsource.type = LightType.Point;
					flsource.range = 20f;
					flsource.color = new Color(0.4f, 1f, 0.6f);
					break;
				case 2:
					flsource.spotAngle = 80f;
					break;
				}
			}
			if (GUI.Button(new Rect(210f, 100f, 180f, 40f), "Slender Man Mythos"))
			{
				view.flashlight.Play();
				mythosmenu = true;
			}
			if (GUI.Button(new Rect(210f, 150f, 85f, 40f), "Options"))
			{
				view.flashlight.Play();
				optmenu = true;
			}
			if (GUI.Button(new Rect(305f, 150f, 85f, 40f), "Extras"))
			{
				view.flashlight.Play();
				extmenu = true;
			}
			if (GUI.Button(new Rect(210f, 200f, 180f, 40f), "Credits"))
			{
				thememusic.Stop();
				view.flashlight.Play();
				view.mh = false;
				view.lost = true;
				view.pages = 8;
				view.endgame.timeleft = 950;
				view.fadeinmusic = 0f;
				gamestarted = true;
				timer = 1600;
			}
			if (GUI.Button(new Rect(210f, 250f, 180f, 40f), "Quit") || view.backedup)
			{
				view.flashlight.Play();
				Application.Quit();
				view.backedup = false;
			}
		}
		else if (mythosmenu)
		{
			if (!youtubemenu && !infomenu)
			{
				if (GUI.Button(new Rect(180f, 100f, 240f, 40f), "Slender Man YouTube Series"))
				{
					view.flashlight.Play();
					youtubemenu = true;
				}
				if (GUI.Button(new Rect(180f, 150f, 240f, 40f), "Other vlogs, blogs, and info"))
				{
					view.flashlight.Play();
					infomenu = true;
				}
				if (GUI.Button(new Rect(210f, 250f, 180f, 40f), "Back") || view.backedup)
				{
					view.flashlight.Play();
					mythosmenu = false;
					view.backedup = false;
				}
			}
			else if (youtubemenu)
			{
				if (GUI.Button(new Rect(160f, 75f, 135f, 40f), "Marble Hornets"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://www.youtube.com/user/MarbleHornets");
				}
				if (GUI.Button(new Rect(305f, 75f, 135f, 40f), "everymanHYBRID"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://www.youtube.com/user/EverymanHybrid");
				}
				if (GUI.Button(new Rect(160f, 125f, 135f, 40f), "TribeTwelve"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://www.youtube.com/user/TribeTwelve ");
				}
				if (GUI.Button(new Rect(305f, 125f, 135f, 40f), "Dark Harvest"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://www.youtube.com/user/DarkHarvest00");
				}
				if (GUI.Button(new Rect(160f, 175f, 135f, 40f), "Anderson Journals"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://www.youtube.com/user/MLAndersen0");
				}
				if (GUI.Button(new Rect(305f, 175f, 135f, 40f), "Caught Not Sleeping"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://www.youtube.com/user/CaughtNotSleeping");
				}
				if (GUI.Button(new Rect(210f, 250f, 180f, 40f), "Back") || view.backedup)
				{
					view.flashlight.Play();
					youtubemenu = false;
					view.backedup = false;
				}
			}
			else if (infomenu)
			{
				if (GUI.Button(new Rect(180f, 100f, 240f, 40f), "www.slendermanmythos.com"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://www.slendermanmythos.com/lexicon/");
				}
				if (GUI.Button(new Rect(180f, 150f, 240f, 40f), "unfiction forums"))
				{
					view.flashlight.Play();
					Application.OpenURL("http://forums.unfiction.com/forums/index.php?f=264");
				}
				if (GUI.Button(new Rect(210f, 250f, 180f, 40f), "Back") || view.backedup)
				{
					view.flashlight.Play();
					infomenu = false;
					view.backedup = false;
				}
			}
		}
		else if (extmenu)
		{
			if (modeoff)
			{
				GUI.Toggle(new Rect(210f, 50f, 180f, 20f), true, "Normal Mode");
			}
			else
			{
				modeoff = GUI.Toggle(new Rect(210f, 50f, 180f, 20f), false, "Normal Mode");
				if (modeoff)
				{
					view.flashlight.Play();
					view.mh = false;
					view.daytime = false;
					PlayerPrefs.SetInt("currentm", 0);
				}
			}
			if (sunup)
			{
				if (view.mh)
				{
					GUI.Toggle(new Rect(210f, 75f, 180f, 20f), true, "Marble Hornets Mode");
				}
				else
				{
					view.mh = GUI.Toggle(new Rect(210f, 75f, 180f, 20f), false, "Marble Hornets Mode");
					if (view.mh)
					{
						view.flashlight.Play();
						modeoff = false;
						view.daytime = false;
						PlayerPrefs.SetInt("currentm", 1);
					}
				}
				if (view.daytime)
				{
					GUI.Toggle(new Rect(210f, 100f, 180f, 20f), true, "Daytime Mode");
				}
				else
				{
					view.daytime = GUI.Toggle(new Rect(210f, 100f, 180f, 20f), false, "Daytime Mode");
					if (view.daytime)
					{
						view.flashlight.Play();
						modeoff = false;
						view.mh = false;
						PlayerPrefs.SetInt("currentm", 2);
					}
				}
			}
			else
			{
				GUI.Toggle(new Rect(210f, 75f, 180f, 20f), false, "???");
				GUI.Toggle(new Rect(210f, 100f, 180f, 20f), false, "???");
			}
			if (!sunup || fltype == 0)
			{
				GUI.Toggle(new Rect(210f, 150f, 180f, 20f), true, "Flashlight");
			}
			else
			{
				bool flag = false;
				if (GUI.Toggle(new Rect(210f, 150f, 180f, 20f), false, "Flashlight"))
				{
					view.flashlight.Play();
					fltype = 0;
					PlayerPrefs.SetInt("fltype", 0);
				}
			}
			if (sunup)
			{
				if (fltype == 1)
				{
					GUI.Toggle(new Rect(210f, 175f, 180f, 20f), true, "Glowstick");
				}
				else
				{
					bool flag = false;
					if (GUI.Toggle(new Rect(210f, 175f, 180f, 20f), false, "Glowstick"))
					{
						view.flashlight.Play();
						fltype = 1;
						PlayerPrefs.SetInt("fltype", 1);
					}
				}
				if (fltype == 2)
				{
					GUI.Toggle(new Rect(210f, 200f, 180f, 20f), true, "Crank Lantern");
				}
				else
				{
					bool flag = false;
					if (GUI.Toggle(new Rect(210f, 200f, 180f, 20f), false, "Crank Lantern"))
					{
						view.flashlight.Play();
						fltype = 2;
						PlayerPrefs.SetInt("fltype", 2);
					}
				}
			}
			else
			{
				GUI.Toggle(new Rect(210f, 175f, 180f, 20f), false, "???");
				GUI.Toggle(new Rect(210f, 200f, 180f, 20f), false, "???");
			}
			if (GUI.Button(new Rect(210f, 250f, 180f, 40f), "Back") || view.backedup)
			{
				view.flashlight.Play();
				extmenu = false;
				view.backedup = false;
			}
		}
		else if (optmenu)
		{
			bool inverted = mly.inverted;
			mly.inverted = GUI.Toggle(new Rect(210f, 50f, 180f, 20f), mly.inverted, "Invert Mouse");
			if (inverted != mly.inverted)
			{
				view.flashlight.Play();
				if (mly.inverted)
				{
					PlayerPrefs.SetInt("minvert", 1);
				}
				else
				{
					PlayerPrefs.SetInt("minvert", 0);
				}
			}
			GUI.Label(new Rect(210f, 75f, 80f, 20f), "Sensitivity");
			float sensitivityX = mlx.sensitivityX;
			sensitivityX = GUI.HorizontalSlider(new Rect(290f, 80f, 115f, 15f), sensitivityX, 1f, 30f);
			if (sensitivityX != mlx.sensitivityX)
			{
				mlx.sensitivityX = sensitivityX;
				mly.sensitivityY = sensitivityX;
				PlayerPrefs.SetFloat("msensitivity", sensitivityX);
			}
			GUI.Label(new Rect(210f, 125f, 80f, 20f), "Grass Level");
			float detailObjectDensity = land.detailObjectDensity;
			detailObjectDensity = GUI.HorizontalSlider(new Rect(290f, 130f, 115f, 15f), detailObjectDensity, 0f, 1f);
			if (detailObjectDensity != land.detailObjectDensity)
			{
				land.detailObjectDensity = detailObjectDensity;
				PlayerPrefs.SetFloat("grasslevel", detailObjectDensity);
			}
			GUI.Label(new Rect(210f, 150f, 80f, 20f), "Tree Detail");
			float treeBillboardDistance = land.treeBillboardDistance;
			treeBillboardDistance = GUI.HorizontalSlider(new Rect(290f, 155f, 115f, 15f), treeBillboardDistance, 20f, 80f);
			if (treeBillboardDistance != land.detailObjectDensity)
			{
				land.treeBillboardDistance = treeBillboardDistance;
				land.treeMaximumFullLODCount = (int)(treeBillboardDistance * 2f);
				PlayerPrefs.SetFloat("trees", treeBillboardDistance);
			}
			bool dustyair = view.dustyair;
			view.dustyair = GUI.Toggle(new Rect(210f, 175f, 180f, 20f), view.dustyair, "Fog");
			if (dustyair != view.dustyair)
			{
				view.flashlight.Play();
				if (view.dustyair)
				{
					PlayerPrefs.SetInt("dusty", 1);
				}
				else
				{
					PlayerPrefs.SetInt("dusty", 0);
				}
			}
			bool flag2 = skintro;
			skintro = GUI.Toggle(new Rect(210f, 200f, 180f, 20f), skintro, "Skip Intro");
			if (flag2 != skintro)
			{
				view.flashlight.Play();
				if (skintro)
				{
					PlayerPrefs.SetInt("skintro", 1);
				}
				else
				{
					PlayerPrefs.SetInt("skintro", 0);
				}
			}
			if (GUI.Button(new Rect(210f, 250f, 180f, 40f), "Back") || view.backedup)
			{
				view.flashlight.Play();
				optmenu = false;
				view.backedup = false;
			}
		}
		GUI.EndGroup();
	}

	private void Update()
	{
		if (!gamestarted && Input.GetKeyDown(KeyCode.Escape))
		{
			if (optmenu)
			{
				optmenu = false;
			}
			else if (extmenu)
			{
				extmenu = false;
			}
			else
			{
				Application.Quit();
			}
		}
	}

	private void FixedUpdate()
	{
		if (timer >= 1600 || !gamestarted)
		{
			return;
		}
		timer++;
		if (timer >= 700 && timer < 1700 && !view.mh)
		{
			spotlight.Rotate(new Vector3(0f, base.transform.rotation.x + Time.deltaTime * 5f, 0f));
		}
		if (timer != 1600)
		{
			return;
		}
		mainview.enabled = true;
		base.GetComponent<Camera>().enabled = false;
		view.fadeoutgui = 0;
		if (!view.daytime)
		{
			if (!view.mh)
			{
				flashlight.Play();
			}
		}
		else
		{
			sun.enabled = true;
			RenderSettings.ambientLight = Color.gray;
		}
	}
}
