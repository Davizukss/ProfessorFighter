using UnityEngine;

public class moves : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;
    public bool verificaChao;
    public Transform detectaChao;
    public LayerMask Chao;
    public Animator animate;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction > 0)
        {
            transform.localScale = facingRight;
        }
        if(direction < 0){
            transform.localScale = facingLeft;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            animate.SetBool("andando", true);
        }
        else
        {
            animate.SetBool("andando", false);
            
        }
        verificaChao = Physics2D.OverlapCircle(detectaChao.position, 0.5f, Chao);
            if (Input.GetButtonDown("Jump") && verificaChao == true)
            {
                rb.velocity = Vector2.up * 12;
                animate.SetBool("pulando", true);

            }
            if( rb.velocity.y < 1)
            {
                animate.SetBool("pulando", false);
            }
        
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
}
