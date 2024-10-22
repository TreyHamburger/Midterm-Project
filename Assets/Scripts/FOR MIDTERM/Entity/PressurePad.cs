using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask pickupLayer;

    public UnityEvent OnCubePlaced;
    public UnityEvent OnCubeRemoved;

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collider of the cube is close enough to the center of the pressure pad
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayer);

        foreach(var collider in hitColliders)
        {
            Debug.Log("Collider in contact = " + collider.gameObject.name);

            if(collider.CompareTag("PickCube"))
            {
                OnCubePlaced?.Invoke();
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("PickCube"))
        {
            OnCubeRemoved?.Invoke();
        }
    }
}
