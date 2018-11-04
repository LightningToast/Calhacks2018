using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple dart with basic functionality
/// </summary>
public class SimpleDart : MonoBehaviour {

    public float baseSpeed;

    public float deathtime;

    /// <summary>
    /// This command fires the projectile forward
    /// </summary> 
    /// <param name="gunSpeedMod">This is the speed modifier of the parent </param>
    public void Fire()
    {
        
        Vector3 normAng = transform.rotation * Vector3.forward;
        GetComponent<Rigidbody>().velocity = (normAng * baseSpeed);

        ///lets set how long until it dies
        Destroy(gameObject, deathtime);
    }

}
