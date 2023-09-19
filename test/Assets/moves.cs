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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verificaChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, Chao);
            if (Input.GetButtonDown("Jump") && verificaChao == true)
            {
                rb.velocity = Vector2.up * 12;
            }
        
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
}
