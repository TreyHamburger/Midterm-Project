using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorKey : MonoBehaviour, ISelectable 
{
    public UnityEvent onKeyPicked;

    public void OnHoverEnter()
    {
       
    }

    public void OnHoverExit()
    {
       
    }

    public void OnSelect()
    {
        onKeyPicked.Invoke();
        Destroy(gameObject);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            onKeyPicked?.Invoke();
            Destroy(gameObject);
        }
    }*/
}
