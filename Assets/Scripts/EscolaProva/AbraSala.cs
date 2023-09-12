using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbraSala : MonoBehaviour
{


    public GameObject porta;

    public GameObject[] UI;


    public GameObject SegurancaDouglas;
    public GameObject SegurancaGordo;
    public GameObject SegurancaJovem;
    public GameObject TiSeba;

    public GameObject OSamari;
    public GameObject ASamari;

    //public GameObject SegurancaCorre;
    public GameObject Posicao;
    public GameObject CabecaPosicoa;


    public GameObject PanelIlustracao;
    public Text textoIlustracao;
    public GameObject ColisorI;

    public float velocidadeDeMovimento = 1;
    int CharacterSelecionado = 0;

    void Start()
    {
        CharacterSelecionado = GameManager.CharactersIndex;
        
    }

    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {

            Destroy(porta.gameObject);

            // DeathTouch.EstaActivo = true;



            //Seguranca1.gameObject.SetActive(true);
            //Seguranca2.gameObject.SetActive(true);


            textoIlustracao.text = "A sua dívida foi paga com sucesso!\n Agora, tens acesso a aula e estás livre de andar \n pela escola toda. Vá até a sala 12 \n no Primeiro Piso.";

            //SegurancaCorre.gameObject.SetActive(true);
            TiSeba.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Seguidor.Ataca = false;

            SegurancaDouglas.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            SegurancaGordo.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            SegurancaJovem.gameObject.GetComponent<CapsuleCollider>().enabled = false;

            //Invoke("ActivaSeguranca", 1f);

            PanelIlustracao.SetActive(true);
            ColisorI.gameObject.SetActive(true);

            Invoke("AbraAnim", 1f);
            Invoke("FechaAnim", 4f);

            
        }
    }


    public void AbraAnim()
    {
        if(CharacterSelecionado==0)
        {
            ASamari.gameObject.GetComponent<ThirdPersonInput>().enabled = false;

            
            Camera.main.transform.position = Posicao.transform.position = Vector3.Lerp(Posicao.transform.position, Posicao.transform.position, velocidadeDeMovimento * Time.deltaTime);
            Camera.main.transform.LookAt(CabecaPosicoa.transform);
        }
        else if (CharacterSelecionado == 1)
        {
            OSamari.gameObject.GetComponent<ThirdPersonInput>().enabled = false;

            Camera.main.transform.LookAt(CabecaPosicoa.transform);
            Camera.main.transform.position = Posicao.transform.position = Vector3.Lerp(Posicao.transform.position, Posicao.transform.position, velocidadeDeMovimento * Time.deltaTime);

        }

        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(false);
        }
    }

    public void FechaAnim()
    {
        if (CharacterSelecionado == 0)
        {
            ASamari.gameObject.GetComponent<ThirdPersonInput>().enabled = true;
        }
        else if (CharacterSelecionado == 1)
        {
            OSamari.gameObject.GetComponent<ThirdPersonInput>().enabled = true;
        }

        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(true);
        }


        Destroy(this.gameObject);
    }
}
