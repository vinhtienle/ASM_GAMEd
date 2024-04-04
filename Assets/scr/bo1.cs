using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bo1 : MonoBehaviour
{
    private int _direction; //1 right; -1 left
    Rigidbody2D _rb; //Boar
    public float _speedBoar; //Boar move speed
    void Start()
    {
        _direction = 1;
        _speedBoar = 5f;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector3(_speedBoar * _direction, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("barier"))
        {

            _direction *= -1;
            _rb.gameObject.transform.localScale = new Vector3(_rb.gameObject.transform.localScale.x * -1, 1, 1);
        }
    }
}
