using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


    public enum gunstatus { Active, Reloading };

    /// <summary>
    /// We have an enum that contains all of the gun types we will use
    /// </summary>
    public enum guntype { dartgun };

    /// <summary>
    /// We have an enum that contains all of the 
    /// </summary>
    public enum ammotype { norshots };

    /// <summary>
    /// We have a dictionary which gives info of each ammo type
    /// </summary>
    public static Dictionary<int, float[]> ammoinfo = new Dictionary<int, float[]>()
    {
        {(int)ammotype.norshots, new float[]{1, 1} }
    };



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
