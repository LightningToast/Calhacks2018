using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPeriodically : MonoBehaviour {

    public ProjectileGun gun;

    public float timeShoot;

    public float timer;

	// Use this for initialization
	void Start () {
        gun = GetComponent<ProjectileGun>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            gun.SpawnShot();
            timer = timeShoot;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
	}
}
