using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direcao : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool flipx;
    private float direction;
    private bool followPlayerDirection = false;
    private Vector3 lastPlayerDirection;

    public int moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        // Verifica se o jogador atirou
        if (Input.GetMouseButtonDown(0))
        {
            // Calcula a direção do jogador no momento do tiro
            lastPlayerDirection = Vector3.right * direction;

            // Habilita o acompanhamento da direção
            followPlayerDirection = true;
        }

        if (followPlayerDirection)
        {
            // Inverte a direção para seguir a direção do último tiro do jogador
            if (lastPlayerDirection.x < 0 && !flipx)
            {
                Flip();
            }
            else if (lastPlayerDirection.x > 0 && flipx)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        flipx = !flipx;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
