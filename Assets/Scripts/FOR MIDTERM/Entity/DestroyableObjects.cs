using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IDestroyable
{
    public void OnCollided()
    {
        Destroy(gameObject);
    }

}
