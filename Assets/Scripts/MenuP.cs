using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuP : MonoBehaviour
{
    public GameObject PanelOpcao;
    public GameObject PanelNivel;
    public GameObject PanelNivelInformatica;
    public GameObject PanelNivelProva;
    public GameObject PanelEU;
    public GameObject PanelDefinicao;
    public GameObject PanelAvisaExpermento;
    public GameObject PanelAvisaPeriodo;
    public GameObject PanelAvisaExpermentoEP;
    public GameObject PanelAvisaPeriodoEP;

    public GameObject[] Missao;
    public int MissaoIndex = 0;

    
    public Text TextoAvisaLivro;
    public Text TextoAvisaLivroEP;

    public Text[] TextoTotalLivro;

    public Text TextoPrecoCFB;

    public Text TextoPrecoPeriodo;
    public Text TextoPrecoPeriodoEP;

    public GameObject BotaoOpcao;
    public GameObject BotaoJogar;

    public GameObject BotaoJogarMCFB;
    public GameObject BotaoCompraCFB;

    public GameObject BotaoJogarMPeriodo;
    public GameObject BotaoCompraPeriodo;

    public GameObject BotaoJogarMPeriodoEP;
    public GameObject BotaoCompraPeriodoEP;

    public GameObject PanelTLiPeriodo;
    public GameObject PanelTLiPeriodoEP;

    public GameObject PanelTLiCFB;

    public GameObject PersonagemEsperanca;
    public GameObject PersonagemSamari;


    



    string MissaoProvaCFB;
    string MissaoPeriodoManha;
    string MissaoPeriodoManhaEP;

    int totalLivroSalvo = 0;
    int precoCompraCFB = 15000;
    int precoCompraPeriodo = 2000;
    int precoCompraPeriodoEP = 1700;

    int CharacterSelecionado = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextoPrecoCFB.text = precoCompraCFB.ToString();
        TextoPrecoPeriodo.text = precoCompraPeriodo.ToString();
        TextoPrecoPeriodoEP.text = precoCompraPeriodoEP.ToString();

        totalLivroSalvo = GameManager.livrosalvo;

        for (int i = 0; i < TextoTotalLivro.Length; i++)
        {
            TextoTotalLivro[i].text = totalLivroSalvo.ToString();
        }

        VerificaMissoes(); // Chama a funcao que verifica se as missoes estao pagas ou nao.
        VerificaPersonagemSelecionado(); //Verifica O PErsonagem que estiver selecionado.
    }

    // Update is called once per frame
    void Update()
    {
        totalLivroSalvo = GameManager.livrosalvo;

        for (int i = 0; i < TextoTotalLivro.Length; i++)
        {
            TextoTotalLivro[i].text = totalLivroSalvo.ToString();
        }


        VerificaMissoes(); // Chama a funcao que verifica se as missoes estao pagas ou nao.
        VerificaPersonagemSelecionado(); //Verifica O PErsonagem que estiver selecionado.
        

    }  

    #region Mudar Missao

    public void ChangeMissao(int index)
    {
        MissaoIndex += index;

        if (MissaoIndex>=Missao.Length)
        {
            MissaoIndex = 0;
        }
        else if (MissaoIndex<0)
        {
            MissaoIndex = Missao.Length - 1;
        }

        for (int i = 0; i < Missao.Length; i++)
        {
            if (i == MissaoIndex)
            {
                Missao[i].SetActive(true);
                TextoAvisaLivro.text = "";
            }
            else
            {
                Missao[i].SetActive(false);
                TextoAvisaLivro.text = "";
            }
        }
    }

    #endregion

    #region Panel Opcao
    public void AbriPanelOpcao()
    {
        if (PanelOpcao.active == false)
        {
            PanelOpcao.SetActive(true);
        }
        else
        {
            PanelOpcao.SetActive(false);
        }
    }
    public void FechaPanelOpcao()
    {
        PanelOpcao.SetActive(false);
    }

    #endregion

    #region Panel Nivel

    public void AbrirPanelNivel()
    {
        PanelNivel.SetActive(true);
    }
    public void FecharPanelNivel()
    {
        PanelNivel.SetActive(false);
    }

    #endregion

    #region Panel Nivel Informatica

    public void AbrirPanelNivelInfor()
    {
        PanelNivelInformatica.SetActive(true);
    }
    public void FecharPanelNivelInfor()
    {
        PanelNivelInformatica.SetActive(false);
    }

    #endregion

    #region Panel Nivel Prova

    public void AbrirPanelNivelProva()
    {
        PanelNivelProva.SetActive(true);
    }
    public void FecharPanelNivelProva()
    {
        PanelNivelProva.SetActive(false);
    }

    #endregion

    #region Panel Eu

    public void AbrirPanelEu()
    {
        PanelEU.SetActive(true);
        BotaoOpcao.SetActive(false);
        BotaoJogar.SetActive(false);
        
    }
    public void FecharPanelEu()
    {
        PanelEU.SetActive(false);
        BotaoOpcao.SetActive(true);
        BotaoJogar.SetActive(true);
        
    }

    #endregion

    #region Panel Definicoes

    public void AbrirPanelDefinicao()
    {
        PanelDefinicao.SetActive(true);
        BotaoOpcao.SetActive(false);
        BotaoJogar.SetActive(false);

    }
    public void FecharPanelDefinicao()
    {
        PanelDefinicao.SetActive(false);
        BotaoOpcao.SetActive(true);
        BotaoJogar.SetActive(true);

    }

    #endregion

    #region Panel Avisa Expermento

    public void AbrirPanelAvisaExp()
    {
        PanelAvisaExpermento.SetActive(true);
    }
    public void FecharPanelAvisaExp()
    {
        PanelAvisaExpermento.SetActive(false);

    }

    #endregion

    #region Panel Avisa ExpermentoEP

    public void AbrirPanelAvisaExpEP()
    {
        PanelAvisaExpermentoEP.SetActive(true);
    }
    public void FecharPanelAvisaExpEP()
    {
        PanelAvisaExpermentoEP.SetActive(false);

    }

    #endregion

    #region Panel Avisa Periodo

    public void AbrirPanelAvisaPeriodo()
    {
        PanelAvisaPeriodo.SetActive(true);
    }
    public void FecharPanelAvisaPeriodo()
    {
        PanelAvisaPeriodo.SetActive(false);

    }

    #endregion

    #region Panel Avisa PeriodoEP

    public void AbrirPanelAvisaPeriodoEP()
    {
        PanelAvisaPeriodoEP.SetActive(true);
    }
    public void FecharPanelAvisaPeriodoEP()
    {
        PanelAvisaPeriodoEP.SetActive(false);

    }

    #endregion

    #region Verifica Missoes

    public void VerificaMissoes()
    {
        MissaoProvaCFB = GameManager.MissaoProvaCFB;
        MissaoPeriodoManha = GameManager.MissaoPeriodoManha;
        MissaoPeriodoManhaEP = GameManager.MissaoPeriodoManhaEP;

        #region Verifica Missao CFB
        if (MissaoProvaCFB == "true")
        {
            BotaoJogarMCFB.SetActive(true);
            BotaoCompraCFB.SetActive(false);
            PanelTLiCFB.SetActive(false);

        }
        else if (MissaoProvaCFB == "false")
        {
            BotaoJogarMCFB.SetActive(false);
            BotaoCompraCFB.SetActive(true);
            PanelTLiCFB.SetActive(true);
        }
        #endregion

        #region Verifica Missao Periodo
        if (MissaoPeriodoManha == "true")
        {
            BotaoJogarMPeriodo.SetActive(true);
            BotaoCompraPeriodo.SetActive(false);
            PanelTLiPeriodo.SetActive(false);
        }
        else if (MissaoPeriodoManha == "false")
        {
            BotaoJogarMPeriodo.SetActive(false);
            BotaoCompraPeriodo.SetActive(true);
            PanelTLiPeriodo.SetActive(true);
        }
        #endregion

        #region Verifica Missao Periodo EP
        if (MissaoPeriodoManhaEP == "true")
        {
            BotaoJogarMPeriodoEP.SetActive(true);
            BotaoCompraPeriodoEP.SetActive(false);
            PanelTLiPeriodoEP.SetActive(false);
        }
        else if (MissaoPeriodoManha == "false")
        {
            BotaoJogarMPeriodoEP.SetActive(false);
            BotaoCompraPeriodoEP.SetActive(true);
            PanelTLiPeriodoEP.SetActive(true);
        }
        #endregion
    }

    #endregion

    #region Comprar Missao CFB
    public void CompraMissaoCFB()
    {
        if (precoCompraCFB <= totalLivroSalvo)
        {
            BotaoCompraCFB.SetActive(false);
            BotaoJogarMCFB.SetActive(true);
            PanelTLiCFB.SetActive(false);

            GameManager.MissaoProvaCFB = "true";
            GameManager.livrosalvo = GameManager.livrosalvo - precoCompraCFB;

            PlayerPrefs.SetInt("livrosalvo", GameManager.livrosalvo);
            PlayerPrefs.SetString("MissaoProvaCFB", GameManager.MissaoProvaCFB);

        }
        else
        {
            TextoAvisaLivroEP.text = "Não tens livro suficiente!";
        }

    }
    #endregion

    #region Comprar Missao Periodo
    public void CompraMissaoPeriodo()
    {
        if (precoCompraPeriodo <= totalLivroSalvo)
        {
            BotaoCompraPeriodo.SetActive(false);
            BotaoJogarMPeriodo.SetActive(true);
            PanelTLiPeriodo.SetActive(false);

            GameManager.MissaoPeriodoManha = "true";
            GameManager.livrosalvo = GameManager.livrosalvo - precoCompraPeriodo;

            PlayerPrefs.SetInt("livrosalvo", GameManager.livrosalvo);
            PlayerPrefs.SetString("MissaoPeriodoManha", GameManager.MissaoPeriodoManha);
        }
        else
        {
            TextoAvisaLivro.text = "Não tens livro suficiente!";
        }
    }
    #endregion





    #region Comprar Missao Periodo EP
    public void CompraMissaoPeriodoEP()
    {
        if (precoCompraPeriodoEP <= totalLivroSalvo)
        {
            BotaoCompraPeriodoEP.SetActive(false);
            BotaoJogarMPeriodoEP.SetActive(true);
            PanelTLiPeriodoEP.SetActive(false);

            GameManager.MissaoPeriodoManhaEP = "true";
            GameManager.livrosalvo = GameManager.livrosalvo - precoCompraPeriodo;

            PlayerPrefs.SetInt("livrosalvo", GameManager.livrosalvo);
            PlayerPrefs.SetString("MissaoPeriodoManhaEP", GameManager.MissaoPeriodoManhaEP);
        }
        else
        {
            TextoAvisaLivroEP.text = "Não tens livro suficiente!";
        }
    }
    #endregion






    #region Comecar Jogo com Missoes Diferente

    public void ComecaJogoMissaoLab()
    {
        GameManager.MissaoActual = "informatica";
        GameManager.gm.ComecaJogoLab();
    }

    public void ComecaJogoMissaoExpe()
    {
        GameManager.MissaoActual = "expermento";
        GameManager.gm.ComecaJogoLab();
    }

    public void ComecaJogoMissaoPeriodo()
    {
        GameManager.MissaoActual = "periodo";
        GameManager.gm.ComecaJogoLab();
    }

    public void ComecaJogoMissaoProva()
    {
        GameManager.MissaoActual = "EscolaProva";
        GameManager.gm.ComecaJogoEscPrv();
    }

    public void ComecaJogoMissaoExpeEP()
    {
        GameManager.MissaoActual = "expermentoEP";
        GameManager.gm.ComecaJogoEscPrv();
    }

    public void ComecaJogoMissaoPeriodoEP()
    {
        GameManager.MissaoActual = "periodoEP";
        GameManager.gm.ComecaJogoEscPrv();
    }


    public void IrNoMenuLoja()
    {
        GameManager.gm.Loja();
    }

    #endregion

    #region Verifica Personagem Selecionado

    public void VerificaPersonagemSelecionado()
    {
        CharacterSelecionado = GameManager.CharactersIndex;

        if (CharacterSelecionado == 0)
        {
            PersonagemEsperanca.SetActive(true);
            PersonagemSamari.SetActive(false);

        }
        else if (CharacterSelecionado == 1)
        {
            PersonagemSamari.SetActive(true);
            PersonagemEsperanca.SetActive(false);
        }
    }
    #endregion

}
