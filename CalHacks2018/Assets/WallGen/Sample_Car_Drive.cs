using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Car_Drive : MonoBehaviour {

    int turn_counter = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        turn_counter++;

        this.GetComponent<Rigidbody>().velocity = transform.forward * 10;

        if (turn_counter == 200)
        {
            turn_counter = 0;
            this.transform.rotation = Quaternion.Euler(0, Random.Range(-40, 40), 0);
        }
	}
}
