using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PanelLiChFiSlCl;
    public GameObject PanelBotoesNavega;
    public GameObject PanelBairro;
    public GameObject BotaoPausa;
    public GameObject ImageIlustracao;


    public Text NomeUsuario;

    public GameObject Livros;
    public GameObject Bidons;

    public GameObject cam;
    public GameObject Esperanca;
    public GameObject Samari;

    int CharacterSelecionado = 0;

    void Start()
    {
        CharacterSelecionado = GameManager.CharactersIndex;

        NomeUsuario.text = GameManager.nomeusuario;
        Invoke("FechaPanelBairro",2f);
        Invoke("AbrirPanelBotoes", 3f);
    }



    public void FechaPanelBairro()
    {
        PanelBairro.SetActive(false);
        Livros.gameObject.SetActive(true);
        Bidons.gameObject.SetActive(true);

        cam.gameObject.GetComponent<Cam3Player>().enabled = false;

        if (CharacterSelecionado == 0)
        {
            Esperanca.gameObject.GetComponent<ThirdPersonInput>().enabled = true;
        }
        else if (CharacterSelecionado == 1)
        {
            Samari.gameObject.GetComponent<ThirdPersonInput>().enabled = true;
        }
        
        //camera.renderingPath = RenderingPath.UsePlayerSettings;
    }

    public void AbrirPanelBotoes()
    {
        PanelLiChFiSlCl.SetActive(true);
        PanelBotoesNavega.SetActive(true);
        BotaoPausa.SetActive(true);
        ImageIlustracao.SetActive(true);
        Invoke("FechaInstrucao", 3f);
    }


    public void FechaInstrucao()
    {
        ImageIlustracao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
