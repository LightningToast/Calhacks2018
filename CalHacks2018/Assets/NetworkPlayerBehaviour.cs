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

    public GameObject vrController;
    public GameObject vrHead;
    public GameObject vrLHand;
    public GameObject vrRHand;

    [SyncVar]
    public int score = 0;

    public bool oculusGo = false;
    // Use this for initialization
    void Start () {
        if(isServer) {
            if (!GameObject.Find("Car Base(Clone)"))
            {
                GameObject car = (GameObject)Instantiate(carPrefab, Vector3.zero, Quaternion.identity);
                NetworkServer.Spawn(car);
            }
        }
        if (isLocalPlayer)
        {
            transform.parent = GameObject.Find("Car Base(Clone)").transform;
            transform.localPosition = Vector3.zero;
            CmdSpawnBody();

            if (oculusGo)
            {

            }
            else
            {
                vrController = GameObject.Find("VRPlayer");
                vrHead = vrController.transform.Find("SteamVRObjects/VRCamera").gameObject;
                vrLHand = vrController.transform.Find("SteamVRObjects/LeftHand").gameObject;
                vrRHand = vrController.transform.Find("SteamVRObjects/RightHand").gameObject;

                vrController.transform.parent = GameObject.Find("Car Base(Clone)").transform;
                vrController.transform.localPosition = Vector3.zero;
            }
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

            headset.transform.position = vrHead.transform.position;
            headset.transform.rotation = vrHead.transform.rotation;
            leftHand.transform.position = vrLHand.transform.position;
            leftHand.transform.rotation = vrLHand.transform.rotation;
            rightHand.transform.position = vrRHand.transform.position;
            rightHand.transform.rotation = vrRHand.transform.rotation;
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
