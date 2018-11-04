using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGen : MonoBehaviour {

    public GameObject hot_air_balloon;
    public GameObject small_balloon;
    public GameObject wall_spawn_left;
    public GameObject wall_spawn_right;

    public int y_off = 10;

    public int corridor_width = 20;
    public int spawn_dist = 40;

    public int spawn_freq = 5;
    int counter_l;
    int counter_r;

    // Use this for initialization
    void Start () {
        spawn_freq = Mathf.Max(5, spawn_freq);
        corridor_width = Mathf.Max(6, corridor_width);
        spawn_dist = Mathf.Max(10, spawn_dist);
        wall_spawn_left.transform.localPosition = new Vector3(-1 * (corridor_width / 2), 0, spawn_dist);
        wall_spawn_right.transform.localPosition = new Vector3(corridor_width / 2, 0, spawn_dist);
        counter_l = Random.Range(0, spawn_freq);
        counter_r = Random.Range(0, spawn_freq);
    }

    // Update is called once per frame
    void Update() {
        if (counter_l >= spawn_freq)
        {
            if (Random.Range(0f, 1f) > .9f)
            {
                int rand1 = Random.Range(0, 9);
                GameObject temp = Instantiate((rand1 == 0) ? hot_air_balloon : small_balloon, wall_spawn_left.transform.position + new Vector3(Random.Range(-6, 6), y_off + Random.Range(-3, 3), 0), Quaternion.Euler((rand1 == 0) ? 0 : -90, 0, 0));
                Destroy(temp, 5);
                counter_l = 0;
            }
        }

        counter_l++;

        if (counter_r >= spawn_freq)
        {
            if (Random.Range(0f, 1f) > .9f)
            {
                int rand2 = Random.Range(0, 9);
                GameObject temp2 = Instantiate((rand2 == 0) ? hot_air_balloon : small_balloon, wall_spawn_right.transform.position + new Vector3(Random.Range(-6, 6), y_off + Random.Range(-3, 3), 0), Quaternion.Euler((rand2 == 0) ? 0 : -90, 0, 0));
                Destroy(temp2, 10);
                counter_r = 0;
            }
        }

        counter_r++;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall") {
            Destroy(other.gameObject);
        }
    }*/
}
