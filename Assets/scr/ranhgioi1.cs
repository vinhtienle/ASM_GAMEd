using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranhgioi1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.tag== "vang")
        {
            Destroy( collision.gameObject );
        }
    }
}
