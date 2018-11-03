using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class contains all of the important information about a gun
/// </summary>
public class ProjectileGun : MonoBehaviour {

    /// <summary>
    /// We store what type of gun we currently have
    /// </summary>
    public int gunType
    {
        get; set;
    }

    /// <summary>
    /// We store the type of ammo we are currently using
    /// </summary>
    public int ammoType
    {
        get; set;
    }


    /// <summary>
    /// We store the number of shots we currently have remaining
    /// </summary>
    public int shotsRemain
    {
        get; set;
    }

    /// <summary>
    /// We store what the shooting rate is, should the fire be held down
    /// </summary>
    public float shootRate
    {
        get; set;
    }

    /// <summary>
    /// We have the modifier for how fast our shots will be fired
    /// </summary>
    public float shootSpeed
    {
        get; set;
    }

    /// <summary>
    /// We see if we are firing on endless mode,
    /// </summary>
    public bool freeFire
    {
        get; set;
    }

    /// <summary>
    /// This empty is the location we want to spawn shots from 
    /// </summary>
    public Transform shootLoc
    {
        get; set;
    }

    // Use this for initialization
    void Start() {
            
    }

    /// <summary>
    /// This function is used for setting up the gun
    /// </summary>
    /// <param name="gunType"> The type of gun we want</param>
    /// <param name="ammoType"> The type of ammo we want </param>
    /// <param name="shotsRemain"> The number of shots we start with</param>
    /// <param name="shootRate">The shooting rate of the gun</param>
    /// <param name="shootSpeed">The speed the projectiles are shot</param>
    /// <param name="freeFire">Whether or not the gun starts in freeFire mode</param>
    public void Initialize(int gunType, int ammoType, int shotsRemain, float shootRate, float shootSpeed, bool freeFire)
    {   
        this.gunType = gunType;
        this.ammoType = ammoType;
        this.shotsRemain = shotsRemain;
        this.shootRate = shootRate;
        this.shootSpeed = shootSpeed;
        this.freeFire = freeFire;

        //Now we initialize the location where our amo spawns
        this.shootLoc = transform.Find("Shot Spawn");

    }

    /// <summary>
    /// We instantiate a shot at the required location of the gun, given by the offset
    /// </summary>
    public void SpawnShot()
    {
        //We want to initialize the shot at the shootLoc, so first we get the prefab
        GameObject pref;

        if (ammoType == (int)GunController.ammotype.norshots)
        {
            pref = Resources.Load<GameObject>("Ammo/Normal Shot");
        }

        // GameObject projectile = Instantiate(pref, shootLoc.position, shootLoc.rotation) as GameObject;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
