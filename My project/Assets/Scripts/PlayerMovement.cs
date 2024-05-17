using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro; // score tablosu için

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
        rgb = GetComponent<Rigidbody2D>(); //playerý çaðýrýyoruz
        score = 0;  // baþlarlen score 0
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f); // onun yatay düzlemde hareketine referans verdik
        verticalSpeed = rgb.velocity.y;

        playerScoreTest.text = score.ToString(); // toString yaz yoksa string olarak algýlayamaz
       
    
        
        transform.position += velocity * speedAmount * Time.deltaTime; // döngüde hýzý zamana baðlý olarak arttýrýyoruz
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal"))); // matf mutlak demez isek ters yöne giderken animasyon oluþmaz - deðer olduðu için


        if (Input.GetButtonDown("Jump") && !animator.GetBool("IsJumping") && !animator.GetBool("IsFalling")) // jump butonu(space) basýldýðýnda ve kontrol için o an zýplamýyor ise sürekli havda zýplamasýn diye
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse); // aþaðýdan karaktere bir kuvvet uygulanýp zýplanmasý saðlanýyor
            animator.SetBool("IsJumping", true);
        }
       
      /*  if (animator.GetBool("IsJumping") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            animator.SetBool("IsJumping", false);
        }
     */
        if (Input.GetAxisRaw("Horizontal") == -1) // karakter geriye doðru ilerliyor ise
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);  // playerin rotasyonunu x y z lik düzlemde y yi 180e getir ki dönsün
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)  // kontrol için, player öne giderse
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

