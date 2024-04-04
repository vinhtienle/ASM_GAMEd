using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.U2D.Sprites;
using UnityEngine.SceneManagement;
using UnityEditor.Search;

public class chay : MonoBehaviour
{
    public int coinCount = 0; // Biến để lưu trữ số coin
    public TextMeshProUGUI coinText; // Đối tượng TextMeshPro để hiển thị số coin
    [SerializeField] int coin;
    [SerializeField] TextMeshProUGUI vip;
    public Rigidbody2D rb; //private Rigidbody2D rb;

    //Khai báo biến tham số
    //Tốc độ di chuyển  
    public float moveSpeed;
    //Tốc độ nhảy
    public float jumpSpeed;
    private Animator animator;
    public float jumpForce = 35f; // Lực nhảy của nhân vật
    public int jumpMax = 5; // Số lần nhảy tối đa
    private int jumpsRemaining; // Số lần nhảy còn lại
    private bool canJump = true; // Biến kiểm tra xem có thể nhảy không
    public GameObject panelEndGame;
    public GameObject Menu;
    private bool isPlayer = true;
    public int HighScore;
    public TextMeshProUGUI Score; // Đối tượng TextMeshPro để hiển thị số coin
    public GameObject bulletcoin;
    public Transform vitribulletcoin;
    public float time;
    private float CoinNumber;
    private bool canShoot = true;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "vang")
        {
            coinCount += 10;
            coin += 10;
            Destroy(collision.gameObject);
            UpdateCoinUI();



        }
        if (collision.gameObject.tag == "hoa")
        {
            Destroy(collision.gameObject);

        }


    }
    void Start()
    {
        //Gán giá trị mặc định ban đầu cho tốc độ di chuyển, nhảy
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        Score.text = "HighScore: " + HighScore.ToString("");
        moveSpeed = 7f;

        animator = GetComponent<Animator>();
        jumpsRemaining = jumpMax;


        //Khi chạy, tự tìm 1 Rigidbody2D để gắn vào,
        //Chỉ tìm các component bên trong nó
        rb = GetComponent<Rigidbody2D>();
        coinText.text = "Coins: " + coinCount.ToString(""); // Khởi tạo hiển thị số coin
        vip.text = "Coins: " + coin.ToString("");



    }

    // Update is called once per frame
    void Update()
    {


        //Nếu phím 
        /*        if (Input.GetKeyDown(KeyCode.Space)) playerJump(jumpSpeed);*/

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            Jump();

            animator.SetBool("isJumping", !canJump);

        }

       /* vip.SetText("Điểm : " + coin);*/
        if (Input.GetKeyDown(KeyCode.P))
        {
            show();

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShootCoin(1);
        }


    }
    public void show()
    {
        if (isPlayer)
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
            isPlayer = false;
        }
        else
        {
            Menu.SetActive(false);
            Time.timeScale = 1;
            isPlayer = true;
        }
    }

    private void FixedUpdate()
    {
        playerRun(moveSpeed);
        animator.SetFloat("aVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("bVelocity", rb.velocity.x);
    }

    void playerRun(float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    private void Jump()
    {
        // Áp dụng lực nhảy lên nhân vật
        /*rb.velocity = new Vector2(rb.velocity.x, jumpForce);*/
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsRemaining--; // Giảm số lần nhảy còn lại
        animator.SetTrigger("Jump");
        // Nếu không còn lần nhảy nào, vô hiệu hóa khả năng nhảy
        if (jumpsRemaining == 0)
        {
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Reset lại số lần nhảy và khả năng nhảy khi tiếp đất
            jumpsRemaining = jumpMax;
            canJump = true;
            animator.SetBool("isJumping", !canJump);
        }
        else if (collision.gameObject.tag == "vat")
        {

            Time.timeScale = 0;
            panelEndGame.SetActive(true);

            if (coin > HighScore)
            {
                HighScore = coin;
                PlayerPrefs.SetInt("HighScore", HighScore);
                Score.text = "HighScore: " + HighScore.ToString();
            }

        }
        else if (collision.gameObject.tag == "boar")
        {
            Time.timeScale = 0;
            panelEndGame.SetActive(true);

            if (coin > HighScore)
            {
                HighScore = coin;
                PlayerPrefs.SetInt("HighScore", HighScore);
                Score.text = "HighScore: " + HighScore.ToString();
            }
        }



    }
    public void Restar()
    {
        panelEndGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount.ToString("");
        vip.text = "Coins: " + coin.ToString("");



    }
    public void ShootCoin(int numberOfCoins)
    {
        if (canShoot && coinCount >= numberOfCoins) // Kiểm tra xem có thể bắn và có đủ coin để bắn không
        {
            canShoot = false; // Đặt biến cờ này thành false để ngăn việc bắn tiếp theo
            coinCount -= numberOfCoins; // Trừ đi số coin bắn đi
            UpdateCoinUI(); // Cập nhật giao diện số coin
            StartCoroutine(ShootCoinsCoroutine(numberOfCoins)); // Gọi hàm bắn coin
        }
    }

    // Coroutine để xử lý việc bắn coin
    IEnumerator ShootCoinsCoroutine(int numberOfCoins)
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject bullet = Instantiate(bulletcoin, vitribulletcoin.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(15f, 0f); // Tốc độ di chuyển của coin khi bắn
            yield return new WaitForSeconds(time); // Chờ một khoảng thời gian trước khi bắn coin tiếp theo
        }
        canShoot = true; // Sau khi bắn xong, cho phép bắn tiếp theo
    }
}



