using Assets.Scripts.Mechanic.WarShip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarShipUnityObject : MonoBehaviour
{
    public WarShip warShip;
    // Start is called before the first frame update
    void Start()
    {
        if (warShip != null)
        {
            warShip.InitializeWarShipComponents();
        }
        SetRotationAngle();
    }
    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Set rotation angle")]
    public void SetRotationAngle()
    {
        warShip.warShipMovementController.rotationAngle = transform.rotation.eulerAngles.z;
    }
}
