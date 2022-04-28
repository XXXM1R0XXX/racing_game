using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class men8u : MonoBehaviour

{
    public paused paused;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        paused.gg = 1;
        Destroy(gameObject);
    }
}