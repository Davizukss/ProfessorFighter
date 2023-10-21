using UnityEngine;

public class ataque : MonoBehaviour
{

    public bool atackando;
    public Transform ataquePoint;
    public float ataqueRange = 0.5f;
    public LayerMask Camadainimigo;
    public Animator animator;
    public int dano;

    public float tempoCooldownAta = 0.3f;
    public bool JaPodeAta = true;
    private float tempoUltimoAta;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        atackando = Input.GetButtonDown("Fire2");

        if(atackando == true && JaPodeAta){
            Ataque();
            JaPodeAta = false;
            tempoUltimoAta = Time.time;
        }
        if (!JaPodeAta)
        {
            if (Time.time - tempoUltimoAta >= tempoCooldownAta)
            {
                JaPodeAta = true;
            }
        }

        void Ataque()
        {
            animator.SetTrigger("ataque");
            Collider2D[] atiraInimigos = Physics2D.OverlapCircleAll(ataquePoint.position, ataqueRange, Camadainimigo);
            foreach(Collider2D enemy in atiraInimigos)
            {
                if(enemy.GetComponent<EnemyAI>() != null){
                enemy.GetComponent<EnemyAI>().Danos(10);
                }
                if(enemy.GetComponent<EnemyAIMelee>() != null){
                enemy.GetComponent<EnemyAIMelee>().Danos(10);
                }
            }
       
    }
}
    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(ataquePoint.position,ataqueRange);
    }
    
}
