using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelCharacter;
    [SerializeField] private GameObject painelAdriano;
    [SerializeField] private GameObject painelMarion;
    [SerializeField] private GameObject painelEdson;
    [SerializeField] private GameObject painelNanci;
    [SerializeField] private GameObject painelSelecao;
    [SerializeField] private GameObject SelecAdriano;
    [SerializeField] private GameObject SelecMarion;
    [SerializeField] private GameObject SelecEdson;
    [SerializeField] private GameObject SelecNanci;

    [SerializeField] private GameObject Adriano;
    [SerializeField] private GameObject Edson;
    [SerializeField] private GameObject Marion;
    [SerializeField] private GameObject Nanci;


    void Start(){
        DesabilitarPersonagens();
    }
    private void DesabilitarPersonagens()
    {
        Marion.SetActive(false);
        Adriano.SetActive(false);
        Edson.SetActive(false);
        Nanci.SetActive(false);
    }

    public void AbrirJogar()
    {
        DesabilitarPersonagens();
        painelNanci.SetActive(false);
        painelEdson.SetActive(false);
        painelMarion.SetActive(false);
        painelAdriano.SetActive(false);
        painelCharacter.SetActive(false);
        painelMenuInicial.SetActive(false);
    }

    public void FecharJogar()
    {
        DesabilitarPersonagens();
        painelNanci.SetActive(true);
        painelEdson.SetActive(true);
        painelMarion.SetActive(true);
        painelAdriano.SetActive(true);
        painelCharacter.SetActive(true);
        painelMenuInicial.SetActive(true);
    }

    public void AbrirCharacter()
    {
        DesabilitarPersonagens();
        painelMenuInicial.SetActive(false);
        painelCharacter.SetActive(true);
    }

    public void FecharCharacter()
    {
        DesabilitarPersonagens();
        painelCharacter.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void AbrirAdriano()
    {
        Adriano.SetActive(true);
        painelCharacter.SetActive(false);
    }

    public void FecharAdriano()
    {
        DesabilitarPersonagens();
        painelCharacter.SetActive(true);
    }

    public void AbrirMarion()
    {
        Marion.SetActive(true);
        painelCharacter.SetActive(false);
        painelAdriano.SetActive(false);
    }

    public void FecharMarion()
    {
        DesabilitarPersonagens();
        painelCharacter.SetActive(true);
        painelAdriano.SetActive(true);
    }

    public void AbrirEdson()
    {
        Edson.SetActive(true);
        painelCharacter.SetActive(false);
        painelAdriano.SetActive(false);
        painelMarion.SetActive(false);
    }

    public void FecharEdson()
    {
        DesabilitarPersonagens();
        painelCharacter.SetActive(true);
        painelAdriano.SetActive(true);
        painelMarion.SetActive(true);
    }

    public void AbrirNanci()
    {
        Nanci.SetActive(true);
        painelCharacter.SetActive(false);
        painelAdriano.SetActive(false);
        painelMarion.SetActive(false);
        painelEdson.SetActive(false);
    }

    public void FecharNanci()
    {
        DesabilitarPersonagens();
        painelCharacter.SetActive(true);
        painelAdriano.SetActive(true);
        painelMarion.SetActive(true);
        painelEdson.SetActive(true);
    }

    public void AbrirSelectAdriano()
    {
        DesabilitarPersonagens();
        painelSelecao.SetActive(false);
    }

    public void FecharSelectAdriano()
    {
        DesabilitarPersonagens();
        painelSelecao.SetActive(true);
    }

    public void AbrirSelectMarion()
    {
        DesabilitarPersonagens();
        SelecAdriano.SetActive(false);
        painelSelecao.SetActive(false);
    }

    public void FecharSelectMarion()
    {
        DesabilitarPersonagens();
        SelecAdriano.SetActive(true);
        painelSelecao.SetActive(true);
    }

    public void AbrirSelectEdson()
    {
        DesabilitarPersonagens();
        SelecMarion.SetActive(false);
        SelecAdriano.SetActive(false);
        painelSelecao.SetActive(false);
    }

    public void FecharSelectEdson()
    {
        DesabilitarPersonagens();
        SelecMarion.SetActive(true);
        SelecAdriano.SetActive(true);
        painelSelecao.SetActive(true);
    }

    public void AbrirSelectNanci()
    {
        DesabilitarPersonagens();
        SelecEdson.SetActive(false);
        SelecMarion.SetActive(false);
        SelecAdriano.SetActive(false);
        painelSelecao.SetActive(false);
    }

    public void FecharSelectNanci()
    {
        DesabilitarPersonagens();
        SelecEdson.SetActive(true);
        SelecMarion.SetActive(true);
        SelecAdriano.SetActive(true);
        painelSelecao.SetActive(true);
    }

    public void Sair()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    public void AdrianoVsMarion()
    {
        SceneManager.LoadScene("AdrianoVsMarion");
    }
    public void AdrianoVsEdson()
    {
        SceneManager.LoadScene("AdrianoVsEdson");
    }
    public void AdrianoVsNanci()
    {
        SceneManager.LoadScene("AdrianoVsNanci");
    }

    
    public void MarionVsAdriano()
    {
        SceneManager.LoadScene("MarionVsAdriano");
    }
    public void MarionVsEdson()
    {
        SceneManager.LoadScene("MarionVsEdson");
    }
    public void MarionVsNanci()
    {
        SceneManager.LoadScene("MarionVsNanci");
    }


}
