using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    public float speed = 3.0f;
    public bool curPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(curPlayer)
            Movement();
	}

    private void Movement()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var zAxis = Input.GetAxis("Vertical");

        var spdTime = speed * Time.deltaTime;

        Vector3 pos = transform.position;
        if(xAxis != 0.0f || zAxis != 0.0f)
            pos = new Vector3(transform.position.x + xAxis* spdTime,pos.y, transform.position.z + zAxis* spdTime);
        transform.position = pos;
    }

    public bool Shoot()
    {
        RaycastHit hit;

        //TODO add the distance that the weapon can fire
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if(hit.transform.CompareTag("Player"))
                hit.transform.GetComponent<Actor>().
        }
    }
}
