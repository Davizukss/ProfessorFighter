using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Melee : MonoBehaviour
{
    public float UltRange = 0.5f;
    public LayerMask Camadainimigo;

    public int vida;
    private int vidaMaxima = 100;

    public Image redbar;
    public Image lifebar;

    public Transform Ult;
    public float forcaUlt;
    private bool tiro;
    private bool flipx;

    private float tempoUltimoUlt;
    public bool JaPodeUltar = true;
    public float tempoCooldownUlt = 5f; // Tempo de recarga em segundos
    
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;
    public bool verificaChao;
    public Transform detectaChao;
    public LayerMask Chao;
    public Animator animate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        vida = vidaMaxima;
    }

    void Update()
    {
        if(vida <= 0){
            animate.SetTrigger("morto");
            Invoke("Morte", 0.7f);
        }
        if (Input.GetMouseButtonDown(0) && JaPodeUltar)
        {
            animate.SetTrigger("ultando");
            Ultar();
            JaPodeUltar = false;
            tempoUltimoUlt = Time.time;
        }

        if (!JaPodeUltar)
        {
            if (Time.time - tempoUltimoUlt >= tempoCooldownUlt)
            {
                JaPodeUltar = true;
            }
        }

        if (flipx == true && direction > 0)
        {
            Flip();
        }
        if (flipx == false && direction < 0)
        {
            Flip();
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
        if (rb.velocity.y < 1)
        {
            animate.SetBool("pulando", false);
        }

        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        flipx = !flipx;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        forcaUlt *= -1;
    }

  private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("enemy"))
        {
            Dano(10);
        }
    }

    public void Dano(int dano)
    {
        vida -= dano;
        float vidaNormalizada = (float) vida / vidaMaxima;
        Vector3 newScale = lifebar.rectTransform.localScale;
        newScale.x = vidaNormalizada;
        lifebar.rectTransform.localScale = newScale;
        StartCoroutine(DecreasingRedbar(newScale));
    }

    IEnumerator DecreasingRedbar(Vector3 newScale){
        yield return new WaitForSeconds(0.2f);
        Vector3 redbarScale = redbar.transform.localScale;
        while(redbar.transform.localScale.x > newScale.x)
        {
            redbarScale.x -= Time.deltaTime * 0.25f;
            redbar.transform.localScale = redbarScale;

            yield return null;
        }
        redbar.transform.localScale = newScale;
    }
    private void Morte(){
            Destroy(gameObject);
            Destroy(this.gameObject);
    }
    public void Ultar(){
        Collider2D[] atiraInimigos = Physics2D.OverlapCircleAll(Ult.position, UltRange, Camadainimigo);
            foreach(Collider2D enemy in atiraInimigos)
            {
                enemy.GetComponent<EnemyAI>().Danos(20);
            }
    }


}