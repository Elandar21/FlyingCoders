using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Actor : NetworkBehaviour {

    public float speed = 3.0f;
    public float rotation = 150.0f;
    public bool curPlayer = false;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;

        Movement();

        if(Input.GetAxis("Fire1") != 0)
            CmdShoot();
	}

    private void Movement()
    {
        var yAxis = Input.GetAxis("Horizontal") * Time.deltaTime * rotation;
        var zAxis = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, yAxis, 0);
        transform.Translate(0, 0, zAxis);
    }

    [Command]
    public void CmdShoot()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f; //TODO replace 6 with bullet speed

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f); //TODO change life of bullet from 2.0f to bullet TTL
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.parent = transform;
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
