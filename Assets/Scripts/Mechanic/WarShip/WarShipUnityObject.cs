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
        Initialize();
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

    public virtual void Initialize()
    {
        if (warShip != null)
        {
            warShip.InitializeWarShipComponents();
        }
        warShip.warShipMovementBehavior = new Assets.Scripts.Mechanic.WarShip.Behavior.WarShipMovementBehavior();
        warShip.warShipShootingController = new Assets.Scripts.Mechanic.WarShip.Controllers.WarShipShootingController();
        warShip.warShipWeaponBehavior = new Assets.Scripts.Mechanic.WarShip.Behavior.WarShipWeaponBehavior();
        warShip.warShipMovementController = new Assets.Scripts.Mechanic.WarShip.Controllers.WarShipMovementController();
    }
}
