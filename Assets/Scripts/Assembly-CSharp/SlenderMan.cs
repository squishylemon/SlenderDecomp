using UnityEngine;

public class SlenderMan : MonoBehaviour
{
	public Transform player;

	public PlayerScript view;

	public AudioSource dramatic;

	public int makejump;

	public int mightport;

	public bool justmoved;

	public Renderer model;

	public Vector3 chaser = new Vector3(0f, 0f, 0f);

	public bool chasing;

	public Transform lhand;

	public Transform rhand;

	public Transform testobj;

	public TestScript tos;

	public int busymove;

	public float maxdeviation = 4f;

	public IntroScript startgame;

	public Transform playleft;

	public Transform playright;

	public LoseScript loser;

	public void CheckSanity()
	{
		Vector3 vector = new Vector3(base.transform.position.x, base.transform.position.y + 1.33f, base.transform.position.z);
		float num = Vector3.Distance(vector, player.position);
		float drain = (view.daytime ? Mathf.Pow(2f, (0f - num / 1.5f) / 10f) : ((!view.torch.enabled) ? Mathf.Pow(2f, (0f - num * 2f) / 10f) : Mathf.Pow(2f, (0f - num) / 10f)));
		view.cansee = false;
		RaycastHit hitInfo;
		if (Physics.Raycast(player.position, (vector - player.position).normalized, out hitInfo) && hitInfo.collider.gameObject == base.gameObject)
		{
			view.cansee = true;
			if (!view.justsaw && num < 10f && view.scared <= 0)
			{
				if (!view.mh)
				{
					dramatic.Play();
				}
				else
				{
					view.flicker = 3;
				}
				view.justsaw = true;
				view.scared = 600;
				view.stamina += 15f;
				if (view.stamina > view.maxstam)
				{
					view.stamina = view.maxstam;
				}
			}
			view.drain = drain;
		}
		if (!view.cansee && Physics.Raycast(player.position, (lhand.position - player.position).normalized, out hitInfo) && hitInfo.collider.gameObject == base.gameObject)
		{
			view.cansee = true;
			if (!view.justsaw && num < 10f && view.scared <= 0)
			{
				if (!view.mh)
				{
					dramatic.Play();
				}
				else
				{
					view.flicker = 3;
				}
				view.justsaw = true;
				view.scared = 600;
				view.stamina += 15f;
				if (view.stamina > view.maxstam)
				{
					view.stamina = view.maxstam;
				}
			}
			view.drain = drain;
		}
		if (view.cansee || !Physics.Raycast(player.position, (rhand.position - player.position).normalized, out hitInfo) || !(hitInfo.collider.gameObject == base.gameObject))
		{
			return;
		}
		view.cansee = true;
		if (!view.justsaw && num < 10f && view.scared <= 0)
		{
			if (!view.mh)
			{
				dramatic.Play();
			}
			else
			{
				view.flicker = 3;
			}
			view.justsaw = true;
			view.scared = 600;
			view.stamina += 15f;
			if (view.stamina > view.maxstam)
			{
				view.stamina = view.maxstam;
			}
		}
		view.drain = drain;
	}

	private void FixedUpdate()
	{
		if (view.paused)
		{
			return;
		}
		float num = 149f;
		float num2 = -149f;
		float num3 = 149f;
		float num4 = -149f;
		if (justmoved)
		{
			justmoved = false;
			if (view.cansee)
			{
				view.flicker = 3;
			}
		}
		if (view.pages + view.level > 0 && loser.timeleft == 0)
		{
			Vector3 vector = new Vector3(base.transform.position.x, base.transform.position.y + 0.99f, base.transform.position.z);
			float num5 = Vector3.Distance(vector, player.position);
			RaycastHit hitInfo;
			if (Physics.Raycast(player.position, (vector - player.position).normalized, out hitInfo) && hitInfo.collider.gameObject == base.gameObject && num5 <= 2f)
			{
				if (view.pages >= 8 && !model.enabled)
				{
					model.enabled = true;
					view.flicker = 3;
				}
				view.caught = true;
			}
			if (num5 < 30f)
			{
				RaycastHit hitInfo2;
				if (Physics.Raycast(player.position, (vector - player.position).normalized, out hitInfo2) && hitInfo2.collider.gameObject == base.gameObject && Physics.Raycast(playleft.position, (lhand.position - player.position).normalized, out hitInfo2) && hitInfo2.collider.gameObject == base.gameObject && Physics.Raycast(playright.position, (rhand.position - player.position).normalized, out hitInfo2) && hitInfo2.collider.gameObject == base.gameObject)
				{
					chasing = true;
					chaser = player.position;
				}
			}
			else
			{
				chasing = false;
			}
			if (view.finaldelay > 0)
			{
				view.finaldelay--;
				if (view.finaldelay <= 0)
				{
					busymove = 4;
				}
			}
			else if ((!view.cansee || view.pages + view.level >= 6) && !view.caught)
			{
				if (model.isVisible && view.pages + view.level < 6)
				{
					mightport++;
					if ((mightport > 100 && (double)Random.value <= 0.001) || mightport >= 1100)
					{
						mightport = 0;
						if ((double)Random.value <= 0.5)
						{
							busymove = 4;
						}
					}
				}
				else
				{
					mightport = 0;
					makejump++;
					if (makejump >= 550 - (view.pages + view.level) * 50 && (!chasing || (num5 > 10f && (double)Random.value <= 0.2)))
					{
						makejump = 0;
						if (view.pages >= 8)
						{
							busymove = 3;
						}
						else if (num5 > view.maxrange || (double)Random.value <= 0.1)
						{
							busymove = 4;
						}
						else
						{
							busymove = 3;
						}
					}
				}
				bool flag = false;
				int num6 = 0;
				Vector3 vector2 = new Vector3(0f, 0f, 0f);
				if (busymove == 1)
				{
					if (tos.valid)
					{
						if (tos.hidden || view.pages + view.level >= 6 || !view.flraised)
						{
							vector2 = testobj.position;
							vector2.y = 1f;
							base.transform.position = vector2;
							justmoved = true;
							busymove = 0;
							chasing = false;
						}
						else
						{
							busymove = 3;
							maxdeviation += 0.25f;
						}
					}
					else
					{
						busymove = 3;
						maxdeviation += 0.25f;
					}
					testobj.position = new Vector3(0f, -50f, 0f);
					tos.testing = false;
					tos.valid = true;
					tos.hidden = true;
				}
				else if (busymove == 2)
				{
					if (tos.valid)
					{
						if ((view.pages + view.level <= 5 && (tos.hidden || !view.flraised)) || view.pages + view.level == 6 || view.pages >= 8 || (!tos.hidden && view.pages + view.level == 7))
						{
							vector2 = testobj.position;
							vector2.y = 1f;
							base.transform.position = vector2;
							justmoved = true;
							busymove = 0;
							chasing = false;
						}
						else
						{
							busymove = 4;
						}
					}
					else
					{
						busymove = 4;
					}
					testobj.position = new Vector3(0f, -50f, 0f);
					tos.testing = false;
					tos.valid = true;
					tos.hidden = true;
				}
				else if (busymove == 3)
				{
					while (num6 < 30 && !flag)
					{
						if (num6 >= 30 || flag)
						{
							continue;
						}
						Vector2 insideUnitCircle = Random.insideUnitCircle;
						vector2 = vector + new Vector3(insideUnitCircle.x * 30f, 0f, insideUnitCircle.y * 30f);
						float num7 = Vector3.Distance(vector, vector2);
						float num8 = Vector3.Distance(player.position, vector2);
						if (vector2.x < num && vector2.x > num2 && vector2.z < num3 && vector2.z > num4)
						{
							if (view.pages >= 8 || (!view.torch.enabled && !view.daytime))
							{
								if (num5 > 30f)
								{
									if (num8 > 2f && num7 + num8 - maxdeviation <= num5 && num7 >= 20f)
									{
										flag = true;
									}
								}
								else if (num8 > 2f && num7 + num8 - maxdeviation <= num5 && num7 >= num5 - 10f && num7 <= num5 + 10f)
								{
									flag = true;
								}
							}
							else if (num5 > 30f)
							{
								if (num8 > 8f && num7 + num8 - maxdeviation <= num5 && num7 >= 20f)
								{
									flag = true;
								}
							}
							else if (num8 > 8f && num7 + num8 - maxdeviation <= num5 && num7 >= num5 - 10f && num7 <= num5 + 10f)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							num6++;
							maxdeviation += 0.25f;
						}
					}
					if (flag)
					{
						testobj.position = vector2;
						Quaternion rotation = Quaternion.LookRotation(testobj.position - player.position, Vector3.up);
						rotation.x = 0f;
						rotation.z = 0f;
						testobj.rotation = rotation;
						tos.testing = true;
						tos.valid = true;
						tos.hidden = true;
						busymove = 1;
					}
					else
					{
						maxdeviation += 0.25f;
					}
				}
				else if (busymove == 4)
				{
					while (num6 < 30 && !flag)
					{
						if (num6 < 30 && !flag)
						{
							Vector2 insideUnitCircle = Random.insideUnitCircle.normalized;
							vector2 = player.position + new Vector3(insideUnitCircle.x * view.maxrange, 0f, insideUnitCircle.y * view.maxrange);
							vector2.y = 2.3f;
							float num8 = Vector3.Distance(player.position, vector2);
							if (vector2.x < num && vector2.x > num2 && vector2.z < num3 && vector2.z > num4 && num8 > view.minrange)
							{
								testobj.position = vector2;
								Quaternion rotation2 = Quaternion.LookRotation(testobj.position - player.position, Vector3.up);
								rotation2.x = 0f;
								rotation2.z = 0f;
								testobj.rotation = rotation2;
								tos.testing = true;
								tos.valid = true;
								flag = true;
							}
							else
							{
								num6++;
							}
						}
					}
					if (flag)
					{
						busymove = 2;
					}
				}
				else
				{
					maxdeviation = 4f;
				}
				if (justmoved)
				{
					if (view.cansee)
					{
						view.flicker = 3;
					}
					Quaternion rotation3 = Quaternion.LookRotation(base.transform.position - player.position, Vector3.up);
					rotation3.x = 0f;
					rotation3.z = 0f;
					base.transform.rotation = rotation3;
				}
				if (chasing && !model.isVisible && !view.caught)
				{
					Quaternion rotation4 = Quaternion.LookRotation(vector - chaser, Vector3.up);
					rotation4.x = 0f;
					rotation4.z = 0f;
					base.transform.rotation = rotation4;
					base.transform.Translate(base.transform.forward * ((float)(view.pages + view.level) * -0.5f + 0.5f) * Time.deltaTime, Space.World);
					if (Vector3.Distance(vector, chaser) <= 0.75f)
					{
						chasing = false;
					}
				}
				else if (!view.cansee)
				{
					Quaternion rotation5 = Quaternion.LookRotation(base.transform.position - player.position, Vector3.up);
					rotation5.x = 0f;
					rotation5.z = 0f;
					base.transform.rotation = rotation5;
				}
			}
			else
			{
				mightport = 0;
				busymove = 0;
				if (!view.cansee)
				{
					Quaternion rotation6 = Quaternion.LookRotation(base.transform.position - player.position, Vector3.up);
					rotation6.x = 0f;
					rotation6.z = 0f;
					base.transform.rotation = rotation6;
				}
			}
		}
		if (view.pages >= 8 && ((!view.caught && model.enabled) || loser.timeleft > 1))
		{
			if (view.cansee)
			{
				view.flicker = 3;
			}
			model.enabled = false;
			base.transform.position = new Vector3(0f, -200f, 0f);
		}
	}
}
