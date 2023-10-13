using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelCharacter;
    public void Jogar()
    {

    }
    public void AbrirCharacter()
    {
        painelMenuInicial.SetActive(false);
        painelCharacter.SetActive(true);
    }
    public void FecharCharacter()
    {
        painelCharacter.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void Sair()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}
