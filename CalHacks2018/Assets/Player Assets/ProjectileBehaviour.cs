using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {
    public GameObject paintPrefab;
    Rigidbody rb;

    public GameObject sendingPlayer;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * 50f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Projectile")
        {
            return;
        }
        Vector3 rot = transform.localRotation.eulerAngles;
        rot.z = Random.Range(0f, 180f);
        GameObject paint = (GameObject)Instantiate(paintPrefab, transform.position, Quaternion.Euler(rot));

        paint.transform.parent = collision.collider.transform;
        Destroy(this.gameObject);
    }
}
