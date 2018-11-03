using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerBehaviour : NetworkBehaviour {
    public GameObject carPrefab;
	// Use this for initialization
	void Start () {
        if(!isServer) {
            return;
        }
        GameObject car = (GameObject)Instantiate(carPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.Spawn(car);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
