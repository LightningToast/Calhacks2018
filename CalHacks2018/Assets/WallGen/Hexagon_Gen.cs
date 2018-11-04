using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon_Gen : MonoBehaviour
{

    public GameObject hex_prefab;
    public float hex_offset = 0;
    public float hex_height = 1f;
    float x_off = -1.5f;
    float y_off = Mathf.Sqrt(5) * 2f;

    HashSet<Vector2> phantoms;

    // Use this for initialization
    void Start ()
    {
        phantoms = new HashSet<Vector2>();
        phantoms.Add(new Vector2(0, 10));
        AddHexes(phantoms.GetEnumerator().Current);
    }

    // Update is called once per frame
    void Update ()
    {
        List<Vector2> hold = new List<Vector2>();
        List<Vector2> remove = new List<Vector2>();
        Bounds b = GetComponent<BoxCollider>().bounds;

        foreach (Vector2 pos in phantoms)
        {
            if (b.Contains(new Vector3(pos.x, 0, pos.y)))
            {
                hold.Add(pos);
                StartCoroutine(SpawnHex(pos));
            }
            else if (Vector3.Distance(pos, b.center) > 10)
            {
                remove.Add(pos);
            }
        }

        foreach (Vector2 v in hold) {
            AddHexes(v);
            phantoms.Remove(v);
        }
        foreach (Vector2 v in remove)
        {
            phantoms.Remove(v);
        }
    }

    void printHashSet(HashSet<Vector2> hs) {
        foreach (Vector2 v in hs) {
            Debug.Log(v);
        }
    }

    void AddHexes (Vector2 pos) {
        Vector2 v = new Vector2(x_off * hex_height + pos.x, y_off * hex_height + pos.y);
        phantoms.Add(v);
        phantoms.Add(new Vector2(x_off * hex_height + pos.x, -y_off * hex_height + pos.y));
        phantoms.Add(new Vector2(-x_off * hex_height + pos.x, y_off * hex_height + pos.y));
        phantoms.Add(new Vector2(-x_off * hex_height + pos.x, -y_off * hex_height + pos.y));
        phantoms.Add(new Vector2(pos.x, y_off * 2f * hex_height + pos.y));
        phantoms.Add(new Vector2(pos.x, -y_off * 2f * hex_height + pos.y));
    }

    IEnumerator SpawnHex (Vector2 pos) {
        int time = Random.Range(5, 10);
        float offset = Random.Range(-.5f, .5f);
        GameObject hex = Instantiate(hex_prefab, new Vector3(pos.x, offset - time + hex_offset, pos.y), Quaternion.Euler(-90, 60, 0));
        Destroy(hex, 3);
        for (int x = 0; x < time; x++) {
            hex.transform.position = new Vector3(pos.x, offset + x - time + hex_offset, pos.y);
            yield return null;
        }
    }
}
