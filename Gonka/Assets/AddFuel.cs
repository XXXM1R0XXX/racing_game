using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
    
{
    public NewBehaviourScript NewBehaviourScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewBehaviourScript.fuel = 1;
        Destroy(gameObject);
    }
}
