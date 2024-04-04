using UnityEngine;

public class Paralax : MonoBehaviour
{
    Material mat;//gắn với ảnh được phủ lên 
    float distan;//khoảng cách 

    [Range(0f, 5f)]
    public float speed = 0.2f;//làm chậm tốc độ quay của ảnh 
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distan += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distan);
    }
}