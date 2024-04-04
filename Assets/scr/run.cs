using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomMap : MonoBehaviour
{
   /* public GameObject hoa;
    public GameObject bo;*/
    public List<GameObject> listGround; //Mảng các block bản đồ
    public Transform player;
    public float rangeToDestroyObject = 60f; //Khoảng cách để tạo sẵn map và hủy

    public List<GameObject> listGroundOld; //Mảng chứa các block map được tạo ra


    Vector3 endPos; //Vi tri cuoi cung
    Vector3 nextPos; //Vi tri tiep theo

  private int GroundHelght;
   private int groundLen;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(18f, -2.0f, 0.0f);

        generateBlockMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangeToDestroyObject)
        {
            generateBlockMap();
        }

        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }

    void generateBlockMap()
    {
        for (int i = 0; i < 5; i++)
        {
            float khoangCach = Random.Range(3.7f, 4.5f); //Khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + khoangCach, -2f, 0f);

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int groundID = Random.Range(0, listGround.Count);

            //Tạo ra block bản đồ ngẫu nhiên
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround); //THêm miếng đất vừa tạo vào mảng

            switch (groundID)
            {
                case 0: groundLen = 14; GroundHelght = 3; break;
                case 1: groundLen = 16; GroundHelght = 5; break;
                case 2: groundLen = 17; GroundHelght = 7; break;
                case 3: groundLen = 22; GroundHelght = 4; break;
                case 4: groundLen = 27; GroundHelght = 8; break;
                case 5: groundLen = 32; GroundHelght = 6; break;
                case 6: groundLen = 32; GroundHelght = 6; break;
            }
/*            float sacsuat = Random.Range(0, 1f);
if (sacsuat < 0.3f)
{
    Instantiate(hoa, new Vector3(nextPos.x + 1, nextPos.y + GroundHelght, 0), Quaternion.identity);
}
if (sacsuat < 0.3f)
{
    Instantiate(bo, new Vector3(nextPos.x + 1, nextPos.y + GroundHelght, 0), Quaternion.identity);

}*/
{

}

endPos = new Vector3(nextPos.x + groundLen, -2f, 0f);
        }
    }
}
