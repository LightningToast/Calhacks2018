using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon_Gen : MonoBehaviour
{
    public GameObject hex_prefab0;
    public GameObject hex_prefab1;
    public GameObject hex_prefab2;
    public GameObject hex_prefab3;
    public GameObject hex_prefab4;
    public float hex_offset = 0;
    public float hex_height = 1f;
    float x_off_x = Mathf.Sqrt(5);
    float y_off_x = Mathf.Sqrt(5) / 2f;
    float y_off_z = 1.5f;
    bool initialized = false;

    HashSet<Vector2> phantoms;
    HashSet<Vector2> done;

    // Use this for initialization
    void Start ()
    {
        phantoms = new HashSet<Vector2>();
        done = new HashSet<Vector2>();
        phantoms.Add(new Vector2(0, 0));
        AddHexes(phantoms.GetEnumerator().Current);
        initialized = true;
    }

    // Update is called once per frame
    void Update ()
    {

        if (!initialized)
        {
            phantoms = new HashSet<Vector2>();
            phantoms.Add(new Vector2(0, 0));
            AddHexes(phantoms.GetEnumerator().Current);
            initialized = true;
        }
        
        List<Vector2> remove = new List<Vector2>();
        List<Vector2> remove2 = new List<Vector2>();
        Bounds b = GetComponent<BoxCollider>().bounds;

        foreach (Vector2 coord in phantoms)
        {
            Vector2 pos = ChangeBasis(coord);
            if (b.Contains(new Vector3(pos.x, 0, pos.y)))
            {
                done.Add(coord);
                GameObject prefab = Rand_Pillar();
                GameObject hex = Instantiate(prefab, new Vector3(pos.x, Random.Range(-.5f, .5f) + hex_offset, pos.y), Quaternion.Euler(-90, 0, 0));
                Destroy(hex, 5);
            }
            else if (Vector3.Distance(pos, b.center) > 10)
            {
                remove.Add(pos);
            }
        }

        foreach (Vector2 coord in done)
        {
            Vector2 v = ChangeBasis(coord);
            if (Vector3.Distance(new Vector3(v.x, 0, v.y), b.center) > 10)
            {
                remove2.Add(coord);
            } else
            {
                AddHexes(coord);
                phantoms.Remove(coord);
            }
        }

        foreach (Vector2 v in remove)
        {
            phantoms.Remove(v);
        }
        foreach (Vector2 v in remove2)
        {
            done.Remove(v);
        }
    }

    void printHashSet(HashSet<Vector2> hs) {
        foreach (Vector2 v in hs) {
            Debug.Log(v);
        }
    }

    void AddHexes (Vector2 coord) {
        checkAdd(new Vector2(coord.x, coord.y - 1));
        checkAdd(new Vector2(coord.x + 1, coord.y - 1));
        checkAdd(new Vector2(coord.x - 1, coord.y));
        checkAdd(new Vector2(coord.x + 1, coord.y));
        checkAdd(new Vector2(coord.x, coord.y + 1));
        checkAdd(new Vector2(coord.x + 1, coord.y + 1));
    }

    void checkAdd(Vector2 coord)
    {
        if (!done.Contains(coord))
        {
            phantoms.Add(coord);
        }
    }

    Vector2 ChangeBasis (Vector2 coord)
    {
        return new Vector2((((float)coord.x) * x_off_x + ((float)coord.y) * y_off_x) * hex_height, ((float)coord.y) * y_off_z * hex_height);
    }

    GameObject Rand_Pillar ()
    {
        int x = Random.Range(0, 3);
        switch (x) {
            case 0:
                return hex_prefab0;
            case 1:
                return hex_prefab1;
            case 2:
                return hex_prefab2;
            case 3:
                return hex_prefab3;
            case 4:
                return hex_prefab4;
            default:
                return hex_prefab1;
        }
    }
   
}
