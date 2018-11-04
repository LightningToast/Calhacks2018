using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGen : MonoBehaviour {

    public GameObject wall_prefab;

    public int spawn_freq = 5;
    int counter = 0;

	// Use this for initialization
	void Start () {
        spawn_freq = Mathf.Max(5, spawn_freq);
	}
	
	// Update is called once per frame
	void Update () {
        counter++;

        //if (counter == spawn_freq)
	}
}
