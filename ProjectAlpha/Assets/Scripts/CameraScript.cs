using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform actor;
    public float height = 1.0f;

	// Use this for initialization
	void Start () {
        transform.parent = actor;
        transform.localPosition = new Vector3(0.0f,height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
