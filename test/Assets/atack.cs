using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atack : MonoBehaviour
{
    public bool atackando;
    public Transform ataquePoint;
    public float ataqueRange = 0.5f;
    public LayerMask Camadainimigo;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atackando = Input.GetButtonDown("Fire2");

        if(atackando == true){
            Ataque();
        }

        void Ataque()
        {
            animator.SetTrigger("ataque");
            Collider2D[] atiraInimigos = Physics2D.OverlapCircleAll(ataquePoint.position, ataqueRange, Camadainimigo);

            foreach(Collider2D enemy in atiraInimigos)
            {
                enemy.GetComponent<Player2>().Dano(100);
            }
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(ataquePoint.position,ataqueRange);
    }
}
