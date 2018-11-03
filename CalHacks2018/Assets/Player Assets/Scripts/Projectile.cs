using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    /// <summary>
    /// This is the int dictating what ammo type this is
    /// </summary>
    public GunController.ammotype ammoType;

    /// <summary>
    /// We determine what the base speed of the ammo is
    /// </summary>
    public float baseSpeed;

    /// <summary>
    /// We determine the base rate of fire of the ammo
    /// </summary>
    public float baseRate;

    /// <summary>
    /// This keeps track of the player who fired this gun
    /// </summary>
    public int player;

    /// <summary>
    /// This is the gun from which the projectile will be fire from, null if no owner
    /// </summary>
    public Transform gunOwner;

    /// <summary>
    /// This initializes all of the variables within our ammo
    /// </summary>
    /// <param name="ammo">The type of ammo</param>
    /// <param name="player">The player who owns the projectile</param>
    public void initProjectile(GunController.ammotype ammo)
    {
        ammoType = ammo;
        baseSpeed = GunController.ammoinfo[(int)ammo][0];
        baseRate = GunController.ammoinfo[(int)ammo][1];
    }

    /// <summary>
    /// This sets the player of the projectile
    /// </summary>
    /// <param name="player">The player we want to own the projectile</param>
    public void setPlayer(int player)
    {
        this.player = player;
    }

    /// <summary>
    /// This command fires the projectile forward
    /// </summary> 
    /// <param name="gunSpeedMod">This is the speed modifier of the parent </param>
    public void Fire(float gunSpeedMod)
    {
        Vector3 normAng = transform.rotation * Vector3.forward;
        Debug.Log(normAng);
        GetComponent<Rigidbody>().velocity = ( normAng * gunSpeedMod * baseSpeed);
    }

	// Use this for initialization
	void Start () {

        if ((int)ammoType != 0)
        {
            baseSpeed = GunController.ammoinfo[(int)ammoType][0];
            baseRate = GunController.ammoinfo[(int)ammoType][1];
        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
