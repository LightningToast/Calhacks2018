using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    /// <summary>
    /// This is the int dictating what ammo type this is
    /// </summary>
    public int ammoType;

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
    /// This initializes all of the variables within our ammo
    /// </summary>
    /// <param name="ammo">The type of ammo</param>
    /// <param name="player">The player who owns the projectile</param>
    public void initProjectile(int ammo, int player)
    {
        ammoType = ammo;
        baseSpeed = GunController.ammoinfo[ammo][0];
        baseRate = GunController.ammoinfo[ammo][1];

        this.player = player;
    }

    /// <summary>
    /// This command fires the projectile forward
    /// </summary> 
    /// <param name="gunSpeedMod">This is the speed modifier of the parent </param>
    public void Fire(float gunSpeedMod)
    {
        GetComponent<Rigidbody>().velocity = (Vector3.forward * gunSpeedMod * baseSpeed);
    }

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
