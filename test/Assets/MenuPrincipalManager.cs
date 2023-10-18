using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelCharacter;
    [SerializeField] private GameObject painelAdriano;
    [SerializeField] private GameObject painelMarion;
    [SerializeField] private GameObject painelEdson;
    [SerializeField] private GameObject painelNanci;
    [SerializeField] private GameObject painelSelecao;

    public void AbrirJogar()
    {
        painelNanci.SetActive(false);
        painelEdson.SetActive(false);
        painelMarion.SetActive(false);
        painelAdriano.SetActive(false);
        painelCharacter.SetActive(false);
        painelMenuInicial.SetActive(false);
    }
    public void FecharJogar()
    {
        painelNanci.SetActive(true);
        painelEdson.SetActive(true);
        painelMarion.SetActive(true);
        painelAdriano.SetActive(true);
        painelCharacter.SetActive(true);
        painelMenuInicial.SetActive(true);
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
    public void AbrirAdriano()
    {
        painelCharacter.SetActive(false);
    }
    public void FecharAdriano()
    {
        painelCharacter.SetActive(true);
    }
    public void AbrirMarion()
    {
        painelCharacter.SetActive(false);
        painelAdriano.SetActive(false);
    }
    public void FecharMarion()
    {
        painelCharacter.SetActive(true);
        painelAdriano.SetActive(true);
    }
    public void AbrirEdson()
    {
        painelCharacter.SetActive(false);
        painelAdriano.SetActive(false);
        painelMarion.SetActive(false);
    }
    public void FecharEdson()
    {
        painelCharacter.SetActive(true);
        painelAdriano.SetActive(true);
        painelMarion.SetActive(true);
    }
    public void AbrirNanci()
    {
        painelCharacter.SetActive(false);
        painelAdriano.SetActive(false);
        painelMarion.SetActive(false);
        painelEdson.SetActive(false);
    }
    public void FecharNanci()
    {
        painelCharacter.SetActive(true);
        painelAdriano.SetActive(true);
        painelMarion.SetActive(true);
        painelEdson.SetActive(true);
    }
    public void Sair()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }



}
