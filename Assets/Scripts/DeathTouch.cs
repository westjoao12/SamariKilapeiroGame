using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class DeathTouch : MonoBehaviour {

    private Animator anima;

    public NavMeshAgent NavMesh;

    public GameObject panel;
    public Text TextoJustificativa;

    public GameObject panelLiChFx;

    public Transform OlhaAqui;
    public Transform OlhaAquiSamari;
    public Transform Seguranca;

    GameObject MusicaFundo;

    public Slider SliderVida;
    public GameObject PanelAvisaPerderJogo;
    public Text TextoContaPerder;

    int CharacterSelecionado = 0;
    string MissaoActual;

    void Start()
    {
        CharacterSelecionado = GameManager.CharactersIndex;
        MissaoActual = GameManager.MissaoActual;

        anima = this.GetComponent<Animator>();
        NavMesh = this.GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision jogador)
    {
        if(jogador.gameObject.CompareTag("Player"))
        {
            #region Esperanca
            if (CharacterSelecionado == 0)
            {

                SliderVida.value -= 1;

                if (SliderVida.value <= 0)
                {
                    #region Game Over
                    Seguranca.transform.LookAt(OlhaAqui);   // Seguranca olha no jogador quando bater nele
                    jogador.gameObject.GetComponent<Animator>().SetBool("morre", true); //Jogador Troca animacao para suplicando


                    anima.SetBool("parrado", true);
                    NavMesh.GetComponent<NavMeshAgent>().isStopped = true;
                    // jogador.gameObject.GetComponent<Animator>().SetBool("morre", true);



                    //=====Faz Parrar o seguranca que corre e coloca-o na animação de Idle.======

                    Seguidor.Atacou = true;
                    Seguidor.anima.SetBool("correndo", false);
                    Seguidor.anima.SetBool("atacando", true);
                    Seguidor.agent.GetComponent<NavMeshAgent>().isStopped = true;

                    //===========================================================================


                    //Time.timeScale = 0;
                    GetComponent<AudioSource>().Play();
                    panelLiChFx.gameObject.SetActive(false);
                    panel.gameObject.SetActive(true);
                    TextoJustificativa.text = "Foste pego pelo segurança!";

                    MusicaFundo = GameObject.FindGameObjectWithTag("MainCamera");
                    MusicaFundo.GetComponent<AudioSource>().Stop();

                    Invoke("desativa", 1f);


                    Invoke("ChamaMenu", 5f);
                    #endregion
                }
                else
                {
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    TextoContaPerder.text = SliderVida.value.ToString();
                    PanelAvisaPerderJogo.SetActive(true);
                    Invoke("DesativaPanelAvisaPerder", 2f);
                }

            }
            #endregion

            #region Samari
            else if (CharacterSelecionado == 1)
            {
                SliderVida.value -= 1;

                if (SliderVida.value <= 0)
                {
                    #region Game Over
                    Seguranca.transform.LookAt(OlhaAquiSamari);   // Seguranca olha no jogador quando bater nele
                    jogador.gameObject.GetComponent<Animator>().SetBool("morre", true); //Jogador Troca animacao para suplicando


                    anima.SetBool("parrado", true);
                    NavMesh.GetComponent<NavMeshAgent>().isStopped = true;
                    // jogador.gameObject.GetComponent<Animator>().SetBool("morre", true);



                    //=====Faz Parrar o seguranca que corre e coloca-o na animação de Idle.======

                    Seguidor.Atacou = true;
                    Seguidor.anima.SetBool("correndo", false);
                    Seguidor.anima.SetBool("atacando", true);
                    Seguidor.agent.GetComponent<NavMeshAgent>().isStopped = true;

                    //===========================================================================


                    //Time.timeScale = 0;
                    GetComponent<AudioSource>().Play();
                    panelLiChFx.gameObject.SetActive(false);
                    panel.gameObject.SetActive(true);
                    TextoJustificativa.text = "Foste pego pelo segurança!";

                    MusicaFundo = GameObject.FindGameObjectWithTag("MainCamera");
                    MusicaFundo.GetComponent<AudioSource>().Stop();

                    Invoke("desativa", 1f);


                    Invoke("ChamaMenu", 5f);
                    #endregion
                }
                else
                {
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    TextoContaPerder.text = SliderVida.value.ToString();
                    PanelAvisaPerderJogo.SetActive(true);
                    Invoke("DesativaPanelAvisaPerder", 2f);
                }
            }
            #endregion

        }
    }

    private void OnCollisionExit(Collision jogador)
    {
        if (CharacterSelecionado == 0)
        {
            Seguranca.transform.LookAt(OlhaAqui);
        }
        else if (CharacterSelecionado == 1)
        {
            Seguranca.transform.LookAt(OlhaAquiSamari);
        }
        
    }

    public void ChamaMenu()
    {
        if(MissaoActual== "informatica")
        {
            GameManager.MissaoActual = "informatica";
            GameManager.gm.Loja();
        }
        else if(MissaoActual== "expermento")
        {
            GameManager.MissaoActual = "expermento";
            GameManager.gm.Loja();
        }
        else if (MissaoActual == "EscolaProva")
        {
            GameManager.MissaoActual = "EscolaProva";
            GameManager.gm.Loja();
        }
        else if(MissaoActual == "expermentoEP")
        {
            GameManager.MissaoActual = "expermentoEP";
            GameManager.gm.Loja();
        }
        
    }

    public void desativa()
    {
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }



    public void DesativaPanelAvisaPerder()
    {
        PanelAvisaPerderJogo.SetActive(false);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

}
