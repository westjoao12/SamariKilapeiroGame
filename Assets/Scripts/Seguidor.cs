using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Seguidor : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    public static NavMeshAgent agent;

    public static Animator anima;

    public static bool Ataca;
    public static bool Atacou = false;

    public Transform Player;
    public Transform Samari;

    public Transform OlhaAqui;
    public Transform OlhaAquiSamari;
    public Transform Seguranca;

    public GameObject panelPerder;
    public Text TextoJustifica;

    public GameObject panelLiChFx;

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
        Atacou = false;

        agent = GetComponent<NavMeshAgent>();
        anima = this.GetComponent<Animator>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!Atacou==true)
        {
            if (Ataca == true)
            {

                anima.SetBool("correndo", true);
                anima.SetBool("atacando", false);

                if (CharacterSelecionado == 0)
                {
                    agent.destination = Player.position;
                }
                else if (CharacterSelecionado == 1)
                {
                    agent.destination = Samari.position;
                }
                
            }
            else if (Ataca == false)
            {
                anima.SetBool("correndo", false);
                anima.SetBool("atacando", false);



                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AreaAtencao")
        {
            Ataca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "AreaAtencao")
        {
            Ataca = false;
        }
    }


    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {
            #region Esperanca
            if (CharacterSelecionado == 0)
            {
                SliderVida.value -= 1;

                if (SliderVida.value <= 0)
                {

                    Atacou = true;
                    #region Game Over


                    Seguranca.transform.LookAt(OlhaAqui);   // Seguranca olha no jogador quando agara-lo
                    jogador.gameObject.GetComponent<Animator>().SetBool("morre", true); //Jogador Troca animacao para suplicando
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

                    anima.SetBool("correndo", false);
                    anima.SetBool("atacando", true);
                    agent.GetComponent<NavMeshAgent>().isStopped = true;



                    GetComponent<AudioSource>().Play();
                    panelLiChFx.gameObject.SetActive(false);
                    panelPerder.gameObject.SetActive(true);
                    TextoJustifica.text = "Foste pego pelo segurança!";

                    MusicaFundo = GameObject.FindGameObjectWithTag("MainCamera");
                    MusicaFundo.GetComponent<AudioSource>().Stop();


                    Invoke("ChamaMenu", 5f);
                    #endregion

                }
                else
                {
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    //Ataca = false;
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

                    Atacou = true;
                    #region Game Over


                    Seguranca.transform.LookAt(OlhaAquiSamari);   // Seguranca olha no jogador quando agara-lo
                    jogador.gameObject.GetComponent<Animator>().SetBool("morre", true); //Jogador Troca animacao para suplicando
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

                    anima.SetBool("correndo", false);
                    anima.SetBool("atacando", true);
                    agent.GetComponent<NavMeshAgent>().isStopped = true;



                    GetComponent<AudioSource>().Play();
                    panelLiChFx.gameObject.SetActive(false);
                    panelPerder.gameObject.SetActive(true);
                    TextoJustifica.text = "Foste pego pelo segurança!";

                    MusicaFundo = GameObject.FindGameObjectWithTag("MainCamera");
                    MusicaFundo.GetComponent<AudioSource>().Stop();


                    Invoke("ChamaMenu", 5f);
                    #endregion

                }
                else
                {
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    //Ataca = false;
                    TextoContaPerder.text = SliderVida.value.ToString();
                    PanelAvisaPerderJogo.SetActive(true);
                    Invoke("DesativaPanelAvisaPerder", 2f);
                }
            }
            #endregion

        }
    }

    public void DesativaPanelAvisaPerder()
    {
        PanelAvisaPerderJogo.SetActive(false);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

    public void ChamaMenu()
    {
        if (MissaoActual == "informatica")
        {
            GameManager.MissaoActual = "informatica";
            GameManager.gm.Loja();
        }
        else if (MissaoActual == "expermento")
        {
            GameManager.MissaoActual = "expermento";
            GameManager.gm.Loja();
        }
        else if (MissaoActual == "EscolaProva")
        {
            GameManager.MissaoActual = "EscolaProva";
            GameManager.gm.Loja();
        }
        else if (MissaoActual == "expermentoEP")
        {
            GameManager.MissaoActual = "expermentoEP";
            GameManager.gm.Loja();
        }

    }

}
