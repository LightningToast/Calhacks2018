using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a dummy script to move and rotate randomly
/// </summary>
public class RandMoveRot : MonoBehaviour {

    public float period = 3;

    public float timeRem;

    public float moveMod;

    public float rotMod;

    public Vector3 randmove;

    public Vector3 randrot;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (timeRem <= 0)
        {
            randmove = new Vector3(Random.value, Random.value, Random.value) * moveMod;
            randrot = new Vector3(Random.value, Random.value, Random.value) * rotMod;
            timeRem = period;
        }
        else
        {
            timeRem -= Time.deltaTime;
            transform.Rotate(randrot);
            transform.Translate(randmove);
        }
        
        
        
		
	}
}
