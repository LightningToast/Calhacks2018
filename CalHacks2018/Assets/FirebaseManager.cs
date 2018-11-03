using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    DatabaseReference reference;
    public bool firebaseEnabled = true;

    public float posX;
    public float posY;
    // Use this for initialization
    void Start()
    {
        if (!firebaseEnabled)
        {
            return;
        }
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://redseptember-5c74c.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        //reference.Child("Missions/Mission1/Ship").Child("PosX").SetValueAsync(0);
        //reference.Child("Missions/Mission1/Ship").Child("PosY").SetValueAsync(0);

        FirebaseDatabase.DefaultInstance.GetReference("Missions/Mission1/Ship/PosX").ValueChanged += HandleValueChangedShipPosX;
        FirebaseDatabase.DefaultInstance.GetReference("Missions/Mission1/Ship/PosY").ValueChanged += HandleValueChangedShipPosY;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {

    }

    void HandleValueChangedShipPosX(object sender, ValueChangedEventArgs args)
    {
        posX = float.Parse(args.Snapshot.Value.ToString());
    }
    void HandleValueChangedShipPosY(object sender, ValueChangedEventArgs args)
    {
        posY = float.Parse(args.Snapshot.Value.ToString());
    }

    public void SendShipPosX(float val)
    {
        if (!firebaseEnabled)
        {
            return;
        }
        //reference.Child("Missions/Mission1/Ship/").Child("PosX").SetValueAsync(val);
    }
    public void SendShipPosY(float val)
    {
        if (!firebaseEnabled)
        {
            return;
        }
        //reference.Child("Missions/Mission1/Ship/").Child("PosY").SetValueAsync(val);
    }
}

