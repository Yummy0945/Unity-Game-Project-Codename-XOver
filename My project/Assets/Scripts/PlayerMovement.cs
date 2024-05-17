using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro; // score tablosu i�in

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rgb;
    Vector3 velocity;
    float verticalSpeed;
    public Animator animator;
    float speedAmount = 5f;
    float jumpAmount = 7f;

    public int score;
    public TextMeshProUGUI playerScoreTest;
    
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>(); //player� �a��r�yoruz
        score = 0;  // ba�larlen score 0
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f); // onun yatay d�zlemde hareketine referans verdik
        verticalSpeed = rgb.velocity.y;

        playerScoreTest.text = score.ToString(); // toString yaz yoksa string olarak alg�layamaz
       
    
        
        transform.position += velocity * speedAmount * Time.deltaTime; // d�ng�de h�z� zamana ba�l� olarak artt�r�yoruz
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal"))); // matf mutlak demez isek ters y�ne giderken animasyon olu�maz - de�er oldu�u i�in


        if (Input.GetButtonDown("Jump") && !animator.GetBool("IsJumping") && !animator.GetBool("IsFalling")) // jump butonu(space) bas�ld���nda ve kontrol i�in o an z�plam�yor ise s�rekli havda z�plamas�n diye
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse); // a�a��dan karaktere bir kuvvet uygulan�p z�planmas� sa�lan�yor
            animator.SetBool("IsJumping", true);
        }
       
      /*  if (animator.GetBool("IsJumping") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            animator.SetBool("IsJumping", false);
        }
     */
        if (Input.GetAxisRaw("Horizontal") == -1) // karakter geriye do�ru ilerliyor ise
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);  // playerin rotasyonunu x y z lik d�zlemde y yi 180e getir ki d�ns�n
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)  // kontrol i�in, player �ne giderse
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // tekrar eski haline getir
        }
        if(animator.GetBool("IsJumping") && verticalSpeed < 0)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Ground")
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);

        }

        }      
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("IsJumping", true);
            
        }
    }
    
}

