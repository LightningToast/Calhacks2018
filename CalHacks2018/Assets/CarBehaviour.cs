using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour {
    public float turn;
    public float maxTurn = 20f;

    public float speed;



    public float approxCheck = 0.01f;
    public float turnRamp = 0.05f;
    public float speedRamp = 0.05f;

    public FirebaseManager manager;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        manager = GetComponent<FirebaseManager>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Mathf.Abs(turn - manager.turn) > approxCheck) {
            turn = Mathf.Lerp(turn, manager.turn, turnRamp);
        }
        if(Mathf.Abs(speed - manager.speed) > approxCheck)
        {
            speed = Mathf.Lerp(speed, manager.speed, speedRamp);
        }

        rb.velocity = transform.forward * speed;
        transform.Rotate(Vector3.up * Time.deltaTime * turn/maxTurn);

    }
}
