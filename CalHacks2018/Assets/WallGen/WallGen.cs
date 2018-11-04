using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGen : MonoBehaviour {

    public GameObject wall_prefab;
    public GameObject wall_spawn_left;
    public GameObject wall_spawn_right;

    public int corridor_width = 20;
    public int spawn_dist = 40;

    public int spawn_freq = 5;
    int counter = 0;

	// Use this for initialization
	void Start () {
        spawn_freq = Mathf.Max(5, spawn_freq);
        corridor_width = Mathf.Max(6, corridor_width);
        spawn_dist = Mathf.Max(10, spawn_dist);
        wall_spawn_left.transform.localPosition = new Vector3(-1 * (corridor_width / 2), 0, spawn_dist);
        wall_spawn_right.transform.localPosition = new Vector3(corridor_width / 2, 0, spawn_dist);
    }
	
	// Update is called once per frame
	void Update () {
        counter++;

        if (counter == spawn_freq) {
            counter = 0;
            Instantiate(wall_prefab, wall_spawn_left.transform.position, transform.rotation);
            Instantiate(wall_prefab, wall_spawn_right.transform.position, transform.rotation);
        }
	}
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall") {
            Destroy(other.gameObject);
        }
    }
}
