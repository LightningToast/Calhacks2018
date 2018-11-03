using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VRShoot : MonoBehaviour
{
    public SteamVR_Action_Boolean shootAction;

    public Hand hand;

    public GameObject Projectile_Prefab;


    private void OnEnable()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();

        if (shootAction == null)
        {
            Debug.LogError("No shoot action assigned");
            return;
        }

        shootAction.AddOnChangeListener(OnShootActionChange, hand.handType);
    }

    private void OnDisable()
    {
        if (shootAction != null)
            shootAction.RemoveOnChangeListener(OnShootActionChange, hand.handType);
    }

    private void OnShootActionChange(SteamVR_Action_In actionIn)
    {
        if (shootAction.GetStateDown(hand.handType))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(Projectile_Prefab, transform.position, transform.rotation);
    }
}
