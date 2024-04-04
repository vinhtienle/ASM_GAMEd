using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Lấy hướng của đối tượng mà slider đang nhắm đến
            Vector3 directionToTarget = target.position - transform.position;

            // Đảo ngược hướng của vector mục tiêu
            Vector3 newDirection = new Vector3(directionToTarget.z, directionToTarget.y, -directionToTarget.x);

            // Lấy góc quay cần thiết để slider quay về hướng của con vật
            Quaternion targetRotation = Quaternion.LookRotation(newDirection, Vector3.up);

            // Áp dụng quay đầu cho slider
            transform.rotation = targetRotation;
        }
    }
}
