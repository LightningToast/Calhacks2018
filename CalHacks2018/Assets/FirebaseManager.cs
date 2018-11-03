using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.Networking;

public class FirebaseManager : NetworkBehaviour
{
    public float turn;
    public float speed;
    // Use this for initialization
    void Start()
    {
        if (!isServer)
        {
            return;
        }
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hornedtomato.firebaseio.com/");

        FirebaseDatabase.DefaultInstance.GetReference("turn").ValueChanged += HandleValueChangedTurn;
        FirebaseDatabase.DefaultInstance.GetReference("speed").ValueChanged += HandleValueChangedSpeed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {

    }

    void HandleValueChangedTurn(object sender, ValueChangedEventArgs args)
    {
        turn = float.Parse(args.Snapshot.Value.ToString());
        print("Turn " + turn);
    }
    void HandleValueChangedSpeed(object sender, ValueChangedEventArgs args)
    {
        speed = float.Parse(args.Snapshot.Value.ToString());
        print("Speed " + speed);
    }
}

