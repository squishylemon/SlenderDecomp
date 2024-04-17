using UnityEngine;

public class SpawnPages : MonoBehaviour
{
	public Transform page1;

	public Transform page2;

	public Transform page3;

	public Transform page4;

	public Transform page5;

	public Transform page6;

	public Transform page7;

	public Transform page8;

	public int whichpage;

	private void FindSpawn(Transform target)
	{
		bool flag = false;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Finish");
		int num = 0;
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (gameObject.tag == "Finish")
			{
				num++;
			}
		}
		GameObject[] array3 = array;
		foreach (GameObject gameObject2 in array3)
		{
			if (flag)
			{
				continue;
			}
			if (Random.value <= 1f / (float)num)
			{
				target.position = gameObject2.transform.position;
				target.rotation = gameObject2.transform.rotation;
				GameObject[] array4 = array;
				foreach (GameObject gameObject3 in array4)
				{
					if (Vector3.Distance(target.position, gameObject3.transform.position) <= 35f)
					{
						Object.Destroy(gameObject3);
					}
				}
				Object.Destroy(gameObject2);
				flag = true;
				return;
			}
			num--;
		}
		if (!flag)
		{
			MonoBehaviour.print("PAGEFAIL");
		}
	}

	private void FixedUpdate()
	{
		if (whichpage >= 9)
		{
			return;
		}
		whichpage++;
		switch (whichpage)
		{
		case 1:
			FindSpawn(page1);
			break;
		case 2:
			FindSpawn(page2);
			break;
		case 3:
			FindSpawn(page3);
			break;
		case 4:
			FindSpawn(page4);
			break;
		case 5:
			FindSpawn(page5);
			break;
		case 6:
			FindSpawn(page6);
			break;
		case 7:
			FindSpawn(page7);
			break;
		case 8:
			FindSpawn(page8);
			break;
		case 9:
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("Finish");
			GameObject[] array2 = array;
			foreach (GameObject obj in array2)
			{
				Object.Destroy(obj);
			}
			break;
		}
		}
	}
}
