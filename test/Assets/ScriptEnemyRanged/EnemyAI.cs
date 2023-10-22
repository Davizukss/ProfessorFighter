using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class EnemyAI : MonoBehaviour
{
    public Transform Ult;
    public SpriteRenderer Projetil;
    
    public int vida = 150;
    private int vidaAtual = 150;
    public float tempo;

    public Image redbarEnemy;
    public Image lifebarEnemy;

    public bool japulou = true;
    public int danoInimigo;
    public float velocidade;
    public float distanciaDeAtaque;
    public float tempoDeEsperaEntreAtaques;

    private bool podeMover = true;

    private bool faceFlip = false; // Adicione inicialização
    private bool hasFlipped = false; // Adicione inicialização
    private Rigidbody2D iniRb;
    private Animator animate;

    private Transform jogador;
    private Transform Enemy;
    private bool podeAtacar = true;
    private float lastAttackTime;

    private bool hitByProjectile = false; // Nova variável para controlar o impacto do projétil
    private float timeSinceHit = 0f; // Tempo desde o impacto do projétil
    public float timeToRecover = 3f;

    void Start()
    {
        animate = GetComponent<Animator>();
        iniRb = GetComponent<Rigidbody2D>();
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        Enemy = GameObject.FindGameObjectWithTag("enemy").transform;
    }

    void Update()
    {
        Vidacena();
        // Verifique a distância entre o inimigo e o jogador.
        float distanciaParaJogador = Vector3.Distance(transform.position, jogador.position);

        if (distanciaParaJogador <= distanciaDeAtaque)
        {
            // O jogador está dentro da distância de ataque.
            if (podeAtacar && Time.time - lastAttackTime >= tempoDeEsperaEntreAtaques)
            {
                animate.SetTrigger("ataque");
                AtacarJogador();

                lastAttackTime = Time.time;
            }
        }

        // Verifique se o inimigo deve mover-se.
        MoverParaJogador();
    }

 void MoverParaJogador()
{
    Vector3 direcao = jogador.position - transform.position;
    float distanciaParaJogador = direcao.magnitude;

    float distanciaDesejada = 8f;

    if (japulou == true)
    {
        animate.SetBool("pulando", true);
        japulou = false;
    }
    else
    {
        animate.SetBool("pulando", false);
    }

    if (hitByProjectile)
    {
        animate.SetBool("andando", false);
        podeMover = false;

        timeSinceHit += Time.deltaTime;
        if (timeSinceHit >= timeToRecover)
        {
            hitByProjectile = false;
            timeSinceHit = 0f;
            podeMover = true; 
            animate.SetBool("andando", true);
            velocidade = 4.5f; 
        }
    }
    else if (distanciaParaJogador <= distanciaDesejada)
    {
        animate.SetBool("andando", false);
        podeMover = false;
    }
    else
    {
        animate.SetBool("andando", true);
        podeMover = true;
    }

    if (podeMover)
    {
        Vector3 movimento = direcao.normalized * velocidade * Time.deltaTime;
        transform.Translate(movimento);
    }
}


    void AtacarJogador()
    {
        // Execute a animação ou lógica de ataque.
        animate.SetTrigger("ataque");
        // Reduza a vida do jogador.
        Melee jogadorScript = jogador.GetComponent<Melee>();
        moves jogadorScript2 = jogador.GetComponent<moves>();
        if (jogadorScript != null)
        {
            jogadorScript.Dano(danoInimigo);
        }
        if (jogadorScript2 != null)
        {
            jogadorScript2.Dano(danoInimigo);
        }
    }


private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("projetil"))
        {
            animate.SetTrigger("tomodano");
            Danos(20);
            hitByProjectile = true;
            timeSinceHit = 0f;
            velocidade = 0;
        }
        else{
            MoverParaJogador();
        }
    }

    public void Danos(int dano)
    {
        if(vidaAtual < vida){
            animate.SetTrigger("tomodano");
        }
        vidaAtual -= dano;
        if (vidaAtual <= 0)
        {
        Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }
            animate.SetTrigger("morto");
            Invoke("Morte", 1f);
        }

        float vidaNormalizada = (float)vidaAtual / vida;
        Vector3 newScale = lifebarEnemy.rectTransform.localScale;
        newScale.x = vidaNormalizada;
        lifebarEnemy.rectTransform.localScale = newScale;
        StartCoroutine(DecreasingRedbar(newScale));
    }

    IEnumerator DecreasingRedbar(Vector3 newScale)
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 redbarScale = redbarEnemy.rectTransform.localScale;

        while (redbarEnemy.rectTransform.localScale.x > newScale.x)
        {
            redbarScale.x -= Time.deltaTime * 0.25f;
            redbarEnemy.rectTransform.localScale = redbarScale;

            yield return null;
        }
        redbarEnemy.rectTransform.localScale = newScale;
    }

    private void FlipEnemy()
    {
        if (!hasFlipped) // Verifica se já flipou antes
        {
            // Inverter a direção do inimigo
            faceFlip = !faceFlip;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            iniRb.velocity = new Vector2(iniRb.velocity.x * -1, iniRb.velocity.y);
            hasFlipped = true; // Marca que já flipou
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null && !col.collider.CompareTag("Player") && col.collider.CompareTag("chao"))
        {
            FlipEnemy();
        }
    }
    private void Morte(){
        Destroy(gameObject);

    }
    public void Vidacena()
    {
        if (vidaAtual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
 
}