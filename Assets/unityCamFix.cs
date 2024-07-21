using UnityEngine;
using System.Collections;

public class unityCamFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Camera>().fieldOfView++;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Camera>().fieldOfView++;
    }
}
