using Assets.Scripts.Mechanic.WarShip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WarShipUnityObject : MonoBehaviour
{
    [HideInInspector]
    public WarShip warShip;
    // Start is called before the first frame update
    void Start()
    {
        if (warShip != null)
        {
            warShip.InitializeWarShipComponents();
        }
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

}
