using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    public Transform bo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = bo.position.x;
        var y = bo.position.y;
        transform.position = new Vector3(x, y);
    }
}
