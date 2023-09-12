using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointEscPrv : MonoBehaviour
{
    public Text[] TextoApreder;

    public Text winText;

    public GameObject personagemPrincipal;
    public GameObject personagemSegundo;

    public GameObject SamariPrincipal;
    public GameObject SamariSegundo;

    public GameObject[] Segurancas;

    public GameObject CadernoFechado;
    public GameObject CadernoAberto;

    public GameObject PanelLiChFi;
    public GameObject PanelAprenda;
    //public GameObject PanelFixa;

    //public GameObject PanelB;
    // public GameObject PanelPrenda;

    public GameObject BotaoPausa;
    public GameObject BotaoDirecao;
    public GameObject BotaoPular;
    public GameObject BotaoCamera;
    public GameObject Cam;

    public GameObject BotaoRecompesa;
    public GameObject TextoRecompesa;


    public GameObject FogoArtificio;

    //public GameObject telaVisualStudio;

    public GameObject Indicador;

    GameObject MusicaFundo;

    int CharacterSelecionado = 0;

    void Start()
    {
        CharacterSelecionado = GameManager.CharactersIndex;
        //SetMission();
    }

    public void SetMission()
    {
        for (int i = 0; i < 1; i++)
        {
            MissionBaseEP mission = GameManager.gm.GetMissionEP(i);
            TextoApreder[i].text = mission.GetMissionDescriptionEP();
        }
    }


    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {
            #region Esperanca
            if (CharacterSelecionado == 0)
            {
                for (int i = 0; i < Segurancas.Length; i++)
                {
                    Segurancas[i].gameObject.SetActive(false);
                }

                personagemPrincipal.gameObject.SetActive(false);
                CadernoFechado.gameObject.SetActive(false);

                //Coloca o Painel onde esta as pontuacoes, invisivel
                PanelLiChFi.gameObject.SetActive(false);


                //PanelChave.gameObject.SetActive(false);
                //PanelFixa.gameObject.SetActive(false);

                BotaoPausa.SetActive(false);

                BotaoDirecao.SetActive(false);
                BotaoPular.SetActive(false);

                Indicador.gameObject.SetActive(false);

                Cam.gameObject.GetComponent<Cam3Player>().enabled = true;

                BotaoCamera.SetActive(true);


                //telaVisualStudio.gameObject.SetActive(true);
                FogoArtificio.gameObject.SetActive(true);
                personagemSegundo.gameObject.SetActive(true);
                CadernoAberto.gameObject.SetActive(true);
                //Time.timeScale = 0;
                winText.gameObject.SetActive(true);
                GetComponent<AudioSource>().Play();

                MusicaFundo = GameObject.FindGameObjectWithTag("MainCamera");
                MusicaFundo.GetComponent<AudioSource>().Stop();

                SetMission();

                Invoke("PanelAprender", 15f);
            }
            #endregion

            #region Samari
            else if (CharacterSelecionado == 1)
            {
                for (int i = 0; i < Segurancas.Length; i++)
                {
                    Segurancas[i].gameObject.SetActive(false);
                }

                SamariPrincipal.gameObject.SetActive(false);
                CadernoFechado.gameObject.SetActive(false);

                //Coloca o Painel onde esta as pontuacoes, invisivel
                PanelLiChFi.gameObject.SetActive(false);


                //PanelChave.gameObject.SetActive(false);
                //PanelFixa.gameObject.SetActive(false);

                BotaoPausa.SetActive(false);

                BotaoDirecao.SetActive(false);
                BotaoPular.SetActive(false);

                Indicador.gameObject.SetActive(false);

                Cam.gameObject.GetComponent<Cam3Player>().enabled = true;

                BotaoCamera.SetActive(true);


                //telaVisualStudio.gameObject.SetActive(true);

                FogoArtificio.gameObject.SetActive(true);

                SamariSegundo.gameObject.SetActive(true);

                CadernoAberto.gameObject.SetActive(true);

                //Time.timeScale = 0;
                winText.gameObject.SetActive(true);
                GetComponent<AudioSource>().Play();

                MusicaFundo = GameObject.FindGameObjectWithTag("MainCamera");
                MusicaFundo.GetComponent<AudioSource>().Stop();

                SetMission();

                Invoke("PanelAprender", 15f);
            }
            #endregion

        }
    }

    private void PanelAprender()
    {
        PanelAprenda.SetActive(true);

        Invoke("AnimaTextoR", 1f);
        Invoke("AnimaBotaoR", 2f);

        //PanelB.gameObject.SetActive(true);

        GameManager.livrosalvo = GameManager.livrosalvo + 200;
        PlayerPrefs.SetInt("livrosalvo", GameManager.livrosalvo);
    }

    public void AnimaTextoR()
    {
        TextoRecompesa.SetActive(true);
        winText.gameObject.SetActive(false);
    }
    public void AnimaBotaoR()
    {
        BotaoRecompesa.SetActive(true);
    }
}
