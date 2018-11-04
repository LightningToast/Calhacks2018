using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour {
    public bool spinning;
    public bool retracting;
    public float spinSpeed = 20f;

    public float boundHeight = 20f;
    public float retractSpeed = 0.1f;

    public GameObject sendingPlayer;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spinning)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);
        }
        else if ((!spinning) && (Mathf.Abs(transform.rotation.eulerAngles.y) > 10f))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed / 2f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if(retracting) {
            Vector3 pos = transform.position;
            pos.y += retractSpeed;
            transform.position = pos;
            if(Mathf.Abs(transform.position.y) > boundHeight) {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((spinning)||retracting) {
            return;
        }
        if(collision.gameObject.GetComponent<ProjectileBehaviour>().sendingPlayer) {
            collision.gameObject.GetComponent<ProjectileBehaviour>().sendingPlayer.GetComponent<NetworkPlayerBehaviour>().score += 50;
        }
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        spinning = true;
        yield return new WaitForSeconds(1);
        spinning = false;
        retracting = true;
    }
}
