using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Car_Drive : MonoBehaviour {

    int turn_counter = 0;
    public int turn_interval = 800;
    public int turn_degree = 30;
    float inc = 0;
    float tot_rot = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        turn_counter++;
        if (turn_counter < turn_interval / 2)
        {
            tot_rot += inc;
        }

        this.GetComponent<Rigidbody>().velocity = transform.forward * 10;

        if (turn_counter == turn_interval)
        {
            turn_counter = 0;
            inc = Random.Range(-turn_degree, turn_degree) * 2 / (float) turn_interval;
        }

        transform.rotation = Quaternion.Euler(0, tot_rot, 0);
    }
}
