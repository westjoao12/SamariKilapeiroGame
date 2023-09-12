using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{

    public Text TextoNomePersonagens;
    public Text TextoLivro;
    public Text TextoChave;
    public Text TextoFixa;
    public Text TextoPrecoSamari;
    public Text TextoAvisa;

    [HideInInspector]
    public int livroS = 0;
    [HideInInspector]
    public int chaveS = 0;
    [HideInInspector]
    public int fixaS = 0;

    public GameObject[] PanelPersonages;
    public GameObject[] Characters;
    public string[] nomePersonagens;

    public GameObject PanelPrecoSamari;
    public GameObject BotaoSelecionarSamari;
    public GameObject BotaoCompraSamari;

    public GameObject BotaoSelecionarEsperanca;

    public GameObject ImgActivoEspe;
    public GameObject ImgActivoSamari;
    public GameObject ImgBloqueado;



    private int CharacterIndex = 0;

    string PersonagemSamari;
    int precoSamari = 18000;
    int CharacterSelecionado=0;

    string MissaoActual;

    void Start()
    {
        Actualizar(); //Actualiza os valores dos livros, Chaves e Fixas.

        VerificaPersonagem(); //Verifica se os Personagens estao pagos.
        VerificaPersonagemSelecionado(); //Verifica o Personagem que esta selecionado.

    }

    
    void Update()
    {
        Actualizar(); //Actualiza os valores dos livros, Chaves e Fixas.

        VerificaPersonagem(); //Verifica se os Personagens estao pagos.
        VerificaPersonagemSelecionado(); //Verifica o Personagem que esta selecionado.
    }

    public void VoltarNoMeno()
    {
        GameManager.gm.chamaMenu();
    }

    public void Jogar()
    {
        if(MissaoActual== "informatica")
        {
            GameManager.MissaoActual = "informatica";
            GameManager.gm.ComecaJogoLab();
        }
        else if (MissaoActual == "expermento")
        {
            GameManager.MissaoActual = "expermento";
            GameManager.gm.ComecaJogoLab();
        }
        else if (MissaoActual == "periodo")
        {
            GameManager.MissaoActual = "periodo";
            GameManager.gm.ComecaJogoLab();
        }
        else if (MissaoActual == "EscolaProva")
        {
            GameManager.MissaoActual = "EscolaProva";
            GameManager.gm.ComecaJogoEscPrv();
        }
        else if (MissaoActual == "expermentoEP")
        {
            GameManager.MissaoActual = "expermentoEP";
            GameManager.gm.ComecaJogoEscPrv();
        }
        else if (MissaoActual == "periodoEP")
        {
            GameManager.MissaoActual = "periodoEP";
            GameManager.gm.ComecaJogoEscPrv();
        }
        else
        {
            GameManager.MissaoActual = "informatica";
            GameManager.gm.ComecaJogoLab();
        }
        
    }

    #region ActualizaChLiFi

    public void Actualizar()
    {
        MissaoActual = GameManager.MissaoActual; //Actualiza a missao actual escolhida.

        TextoPrecoSamari.text = precoSamari.ToString(); //Actualiza o Preco do Personagem Samari.

        livroS = GameManager.livrosalvo;
        TextoLivro.text = livroS.ToString();
        
        chaveS = GameManager.chavesalvo;
        TextoChave.text = chaveS.ToString();

        fixaS = GameManager.fixasalva;
        TextoFixa.text = fixaS.ToString();

    }
    #endregion

    #region Verifica Personagens

    public void VerificaPersonagem()
    {
        PersonagemSamari = GameManager.PersonagemSamari;

        #region Verifica Personagem Samari
        if (PersonagemSamari == "true")
        {
            BotaoSelecionarSamari.SetActive(true);
            BotaoCompraSamari.SetActive(false);
            PanelPrecoSamari.SetActive(false);
            ImgBloqueado.SetActive(false);
        }
        else if (PersonagemSamari == "false")
        {
            BotaoSelecionarSamari.SetActive(false);
            BotaoCompraSamari.SetActive(true);
            PanelPrecoSamari.SetActive(true);
            ImgBloqueado.SetActive(true);
        }

        #endregion
    }

    #endregion

    #region Verifica Personagem Selecionado

    public void VerificaPersonagemSelecionado()
    {
        CharacterSelecionado = GameManager.CharactersIndex;

        if (CharacterSelecionado == 0)
        {
            ImgActivoEspe.SetActive(true);
            ImgActivoSamari.SetActive(false);
            BotaoSelecionarEsperanca.SetActive(false);

            if (PersonagemSamari == "true")
            {
                BotaoSelecionarSamari.SetActive(true);
            }
            
        }
        else if (CharacterSelecionado == 1)
        {
            ImgActivoSamari.SetActive(true);
            ImgActivoEspe.SetActive(false);

            if (PersonagemSamari == "true")
            {
                BotaoSelecionarSamari.SetActive(false);
            }

            BotaoSelecionarEsperanca.SetActive(true);
        }
    }
    #endregion

    #region Seleciona Personagem

    #region Seleciona Esperanca

    public void SelecionaEsperanca()
    {
        GameManager.CharactersIndex = 0;

        PlayerPrefs.SetInt("CharactersIndex", GameManager.CharactersIndex);

        ImgActivoEspe.SetActive(true);
        ImgActivoSamari.SetActive(false);

        
    }
    #endregion

    #region Seleciona Samari

    public void SelecionaSamari()
    {
        GameManager.CharactersIndex = 1;

        PlayerPrefs.SetInt("CharactersIndex", GameManager.CharactersIndex);

        ImgActivoSamari.SetActive(true);
        ImgActivoEspe.SetActive(false); 
    }
    #endregion

    #endregion


    #region Comprar Personagem Samari

    public void CompraPersonagemSamari()
    {
        if (precoSamari <= livroS)
        {
            BotaoSelecionarSamari.SetActive(true);
            BotaoCompraSamari.SetActive(false);
            PanelPrecoSamari.SetActive(false);

            GameManager.PersonagemSamari = "true";
            GameManager.livrosalvo = GameManager.livrosalvo - precoSamari;

            PlayerPrefs.SetInt("livrosalvo", GameManager.livrosalvo);
            PlayerPrefs.SetString("PersonagemSamari", GameManager.PersonagemSamari);

        }
        else
        {
            TextoAvisa.text = "Não tens livros suficientes!";
        }
    }
    #endregion

    #region Mudar Personagens

    public void ChangeCharacter(int index)
    {
        CharacterIndex += index;
        if (CharacterIndex >= Characters.Length)
        {
            CharacterIndex = 0;
        }
        else if (CharacterIndex < 0)
        {
            CharacterIndex = Characters.Length - 1;
        }

        for(int i = 0; i < Characters.Length; i++)
        {
            if (i == CharacterIndex)
            {
                Characters[i].SetActive(true);
                PanelPersonages[i].SetActive(true);
                TextoNomePersonagens.text = nomePersonagens[i];
                TextoAvisa.text = "";
            }
            else
            {
                Characters[i].SetActive(false);
                PanelPersonages[i].SetActive(false);
                TextoAvisa.text = "";
            }
        }
    }
    #endregion

    //public void Recompesa(int valor)
    //{
    //    for (int i = valor; i > 0; i--)
    //    {
    //        GameManager.livrosalvo = GameManager.livrosalvo + 1;

    //        PlayerPrefs.SetInt("livrosalvo", GameManager.livrosalvo);

    //        livroS = GameManager.livrosalvo;
    //        TextoLivro.text = livroS.ToString();

    //        Debug.Log(livroS.ToString());
    //    }
    //}
}
