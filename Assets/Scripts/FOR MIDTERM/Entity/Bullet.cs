using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log($"Collided with {col.gameObject.name}");

        //Checking the existance of the component and assigning it
        IDestroyable destroyable = col.gameObject.GetComponent<IDestroyable>();

        if(destroyable != null)
        {
            destroyable.OnCollided();
        }

        Destroy(gameObject);
    }


    
}
