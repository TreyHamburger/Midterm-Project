using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractor : Interactor


{
    [Header("Pick and Drop")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform attachPoint;
    [SerializeField] private float pickupDistance;
    [SerializeField] private LayerMask pickupLayer;

    private bool isPicked;
    private IPickable pickable;
    private RaycastHit raycastHit;

    public override void Interact()
    {
        //Cast a ray
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out raycastHit, pickupDistance, pickupLayer))
        {
            if (input.activatePressed && !isPicked)
            {
                pickable = raycastHit.transform.GetComponent<IPickable>();

                if (pickable == null)
                    return;

                pickable.OnPicked(attachPoint);
                isPicked = true;
                return;
            }
        }

        if (input.activatePressed && isPicked && pickable != null)
        {
            pickable.OnDropped();
            isPicked = false;
        }
    }
}
