using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerBehaviour : NetworkBehaviour {
    public GameObject carPrefab;

    public GameObject headsetPrefab;
    public GameObject headset;

    public GameObject handPrefab;
    public GameObject leftHand;
    public GameObject rightHand;

    [SyncVar]
    public int score = 0;
    // Use this for initialization
    void Start () {
        if(isServer) {
            if (!GameObject.Find("Car(Clone)"))
            {
                GameObject car = (GameObject)Instantiate(carPrefab, Vector3.zero, Quaternion.identity);
                NetworkServer.Spawn(car);
            }
        }
        if (isLocalPlayer)
        {
            transform.parent = GameObject.Find("Car(Clone)").transform;
            transform.localPosition = Vector3.zero;
            CmdSpawnBody();

        }
    }
	
	// Update is called once per frame
	void Update () {
        if(isLocalPlayer) {
            if(Input.GetKey("d")) {
                Vector3 pos = transform.position;
                pos.x += 0.05f;
                transform.position = pos;
            }
            if (Input.GetKey("a"))
            {
                Vector3 pos = transform.position;
                pos.x -= 0.05f;
                transform.position = pos;
            }

            headset.transform.position = transform.position;
            leftHand.transform.position = transform.position;
            rightHand.transform.position = transform.position;
        }
	}
    [Command]
    public void CmdSpawnBody()
    {
        headset = (GameObject)Instantiate(headsetPrefab, transform.position, transform.rotation);
        leftHand = (GameObject)Instantiate(handPrefab, transform.position, transform.rotation);
        rightHand = (GameObject)Instantiate(handPrefab, transform.position, transform.rotation);

        NetworkServer.SpawnWithClientAuthority(headset, gameObject);
        NetworkServer.SpawnWithClientAuthority(leftHand, gameObject);
        NetworkServer.SpawnWithClientAuthority(rightHand, gameObject);
        RpcRegisterBody(headset, leftHand, rightHand);
    }

    [ClientRpc]
    public void RpcRegisterBody(GameObject head, GameObject lHand, GameObject rHand)
    {
        if(isLocalPlayer) {
            headset = head;
            leftHand = lHand;
            rightHand = rHand;
        }
    }
}
