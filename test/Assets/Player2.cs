using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
   public int vidaAtual = 100;

   public void Dano(int dano){
    vidaAtual -= dano;
        if(vidaAtual <= 0){
            Destroy(this.gameObject);
        }
   }
}
