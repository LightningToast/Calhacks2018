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
    public GunController.guntype gunType;


    /// <summary>
    /// We store the type of ammo we are currently using
    /// </summary>
    public GunController.ammotype ammoType;

    /// <summary>
    /// We store the number of shots we currently have remaining
    /// </summary>
    public int shotsRemain;

    /// <summary>
    /// We have how often the shots can be fired from the gun
    /// </summary>
    public float shootRate;

    /// <summary>
    /// We have the modifier for how fast our shots will be fired out of the gun
    /// </summary>
    public float shootSpeed;

    /// <summary>
    /// We see if we are firing on endless mode,
    /// </summary>
    public bool freeFire;

    /// <summary>
    /// This empty is the location we want to spawn shots from 
    /// </summary>
    public Transform shootLoc;

    public GameObject projectile_prefab;

    /// <summary>
    /// We want to do some housekeeping stuff here
    /// </summary>
    void Start() {
        //If a shootLoc isn't specified, lets just get it from the child
        if (shootLoc == null)
        {
            this.shootLoc = transform.Find("Shot Spawn");
        }
    }

    //for now we just want to stick with the get and set
    /*
    /// <summary>
    /// This function is used for setting up the gun
    /// </summary>
    /// <param name="gunType"> The type of gun we want</param>
    /// <param name="ammoType"> The type of ammo we want </param>
    /// <param name="shotsRemain"> The number of shots we start with</param>
    /// <param name="shootRate">The shooting rate of the gun</param>
    /// <param name="shootSpeed">The speed the projectiles are shot</param>
    /// <param name="freeFire">Whether or not the gun starts in freeFire mode</param>
    public void Initialize(GunController.guntype gunType, GunController.ammotype ammoType, int shotsRemain, float shootRate, float shootSpeed, bool freeFire, )
    {   
        this.gunType = gunType;
        this.ammoType = ammoType;
        this.shotsRemain = shotsRemain;
        this.shootRate = shootRate;
        this.shootSpeed = shootSpeed;
        this.freeFire = freeFire;

    }
    */
    /// <summary>
    /// We instantiate a shot at the required location of the gun, given by the offset
    /// </summary>
    public void SpawnShot()
    {
        //We want to check how much ammo we have and whether we are in freefire mode

        Debug.Log("Spawnshot");
            
        //We want to initialize the shot at the shootLoc, so first we get the prefab
        //GameObject pref;

        /*if (ammoType == (int)GunController.ammotype.norshots)
        {
            pref = Resources.Load<GameObject>("Prefabs/Ammo/Normal Shot");
        }
        else
        {
            pref = null;
        }*/

        GameObject projectile = (GameObject) Instantiate(projectile_prefab, shootLoc.position, shootLoc.rotation);

        //now we want to fire the gun
        projectile.GetComponent<Projectile>().Fire(shootSpeed);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
