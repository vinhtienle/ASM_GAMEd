using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ban : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    public float time;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10f) {
            animator.SetTrigger("dao");
            time = 0.0f;
        }
    }
    private void plaintShoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
