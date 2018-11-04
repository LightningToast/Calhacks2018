using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon_Gen : MonoBehaviour
{

    public GameObject hex_prefab;
    public float hex_height = 5;
    float x_off = -1.5f;
    float y_off = Mathf.Sqrt(5) * 2;

    HashSet<Vector2> phantoms;

    // Use this for initialization
    void Start ()
    {
        phantoms = new HashSet<Vector2>();
        phantoms.Add(new Vector2(0, 0));
        AddHexes(phantoms.GetEnumerator().Current);
    }

    // Update is called once per frame
    void Update ()
    {
        List<Vector2> hold = new List<Vector2>();
        Bounds b = GetComponent<BoxCollider>().bounds;
        HashSet<Vector2>.Enumerator e = phantoms.GetEnumerator();
        while (e.MoveNext()) {
            Vector2 next = e.Current;
            if (b.Contains(next)) {
                hold.Add(next);
                Debug.Log("yip");
                StartCoroutine(SpawnHex(Random.Range(5, 20), new Vector2(next.x, next.y + Random.Range(-2, 2))));
            }
        }

        foreach (Vector2 v in hold) {
            AddHexes(v);
            phantoms.Remove(v);
        }
    }

    void AddHexes (Vector2 pos) {
        phantoms.Add(new Vector2(x_off * hex_height + pos.x, y_off * hex_height + pos.y));
        phantoms.Add(new Vector2(x_off * hex_height + pos.x, -y_off * hex_height + pos.y));
        phantoms.Add(new Vector2(-x_off * hex_height + pos.x, y_off * hex_height + pos.y));
        phantoms.Add(new Vector2(-x_off * hex_height + pos.x, -y_off * hex_height + pos.y));
        phantoms.Add(new Vector2(pos.x, y_off * 2 * hex_height + pos.y));
        phantoms.Add(new Vector2(pos.x, -y_off * 2 * hex_height + pos.y));
    }

    IEnumerator SpawnHex (int time, Vector2 pos) {
        GameObject hex = Instantiate(hex_prefab, new Vector3(pos.x, -time, pos.y), Quaternion.identity);
        for (int x = 0; x < time; x++) {
            hex.transform.position = new Vector3(pos.x, -time + x, pos.y);
            yield return null;
        }
    }
}
