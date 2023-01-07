using Assets.Scripts.Mechanic.Test;
using Assets.Scripts.Mechanic.WarShip;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WarShipUnityObject : MonoBehaviour
{
    public WarShip warShip;
    // Start is called before the first frame update
    void Start()
    {
        InitializeEmptyWarShipComponents();
    }

    private void Update()
    {
        Render();
    }

    public void Render()
    {
        if (warShip != null && warShip.warShipMovementController != null)
        {
            transform.rotation = Quaternion.Euler(0, 0, warShip.warShipMovementController.currentRotationAngle - 90);
            transform.position = new Vector3(
                warShip.warShipMovementController.currentPosition.x,
                warShip.warShipMovementController.currentPosition.y,
                0);
        }
    }

    public virtual void InitializeEmptyWarShipComponents()
    {
        if (warShip.warShipMovementBehavior == null)
            warShip.warShipMovementBehavior = new Assets.Scripts.Mechanic.WarShip.Behavior.WarShipMovementBehavior();
        if (warShip.warShipShootingController == null)
            warShip.warShipShootingController = new Assets.Scripts.Mechanic.WarShip.Controllers.WarShipShootingController();
        if (warShip.warShipWeaponBehavior == null)
            warShip.warShipWeaponBehavior = new Assets.Scripts.Mechanic.WarShip.Behavior.WarShipWeaponBehavior();
        if (warShip.warShipMovementController == null)
            warShip.warShipMovementController = new Assets.Scripts.Mechanic.WarShip.Controllers.WarShipMovementController();
        warShip.SetUpWarShipComponents();
    }
}
