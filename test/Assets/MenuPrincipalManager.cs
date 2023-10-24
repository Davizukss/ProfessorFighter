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

    [SerializeField] private GameObject ComJogar;

    [SerializeField] private GameObject Lutem;
    [SerializeField] private GameObject Um;
    [SerializeField] private GameObject Dois;
    [SerializeField] private GameObject Tres;

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
        ComJogar.SetActive(false);
        
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
        Application.Quit();
    }
    
public void Controles()
{
    ComJogar.SetActive(true);
}

public void ContarTres()
{
    Tres.SetActive(true);
}

public void ContarDois()
{
    Dois.SetActive(true);
}

public void ContarUm()
{
    Um.SetActive(true);
}

public void ContarLutem()
{
    Lutem.SetActive(true);
}

private IEnumerator CarregarCenaComAtraso(string NomeCena)
{
    yield return new WaitForSeconds(4.0f);

    SceneManager.LoadScene(NomeCena);
}
public void AdrianoVsMarion()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("AdrianoVsMarion"));
}


  public void AdrianoVsEdson()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("AdrianoVsEdson"));
}

public void AdrianoVsNanci()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("AdrianoVsNanci"));
}

public void MarionVsAdriano()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("MarionVsAdriano"));
}

public void MarionVsEdson()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("MarionVsEdson"));
}

public void MarionVsNanci()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("MarionVsNanci"));
}

public void EdsonVsAdriano()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("EdsonVsAdriano"));
}

public void EdsonVsMarion()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("EdsonVsMarion"));
}

public void EdsonVsNanci()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("EdsonVsNanci"));
}

public void NanciVsAdriano()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("NanciVsAdriano"));
}

public void NanciVsMarion()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("NanciVsMarion"));
}

public void NanciVsEdson()
{
    Controles();
    Invoke("ContarUm", 3f);
    Invoke("ContarDois", 3.3f);
    Invoke("ContarTres", 3.6f);
    Invoke("ContarLutem", 3.9f);
    StartCoroutine(CarregarCenaComAtraso("NanciVsEdson"));
}

}
