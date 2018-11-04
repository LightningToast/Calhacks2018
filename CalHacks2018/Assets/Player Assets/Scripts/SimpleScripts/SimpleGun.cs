using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple projectile gun
/// </summary>
public class SimpleGun : MonoBehaviour {


    /// <summary>
    /// This is the bullets we will fire
    /// </summary>
    public GameObject projectilePref;

    /// <summary>
    /// This is the location the projectiles will spawn 
    /// </summary>
    public Transform shootLoc;


    /// <summary>
    /// We instantiate a shot at the required location of the gun, given by the offset
    /// </summary>
    public void SpawnShot()
    {
        //We intialize the projecticle from the transform of pref
        GameObject projectile = Instantiate(projectilePref, shootLoc.position, shootLoc.rotation) as GameObject;

        //now we want to fire the gun
        projectile.GetComponent<SimpleDart>().Fire();

    }


}
