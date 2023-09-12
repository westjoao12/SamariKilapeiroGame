using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbraLaboratorio : MonoBehaviour
{

    public GameObject porta;
   

    public GameObject SegurancaDouglas;
    public GameObject SegurancaGordo;
    public GameObject SegurancaJovem;
    public GameObject TiSeba;

    //public GameObject SegurancaCorre;


    public GameObject PanelIlustracao;
    public Text textoIlustracao;
    public GameObject ColisorI;




    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {

            Destroy(porta.gameObject);
        
           // DeathTouch.EstaActivo = true;


            
            //Seguranca1.gameObject.SetActive(true);
            //Seguranca2.gameObject.SetActive(true);


            textoIlustracao.text = "A sua dívida foi paga com sucesso!\n Agora, tens acesso a aula e estás livre de andar \n pela escola toda. Vá até a sala de informática no ultimo Piso.";

            //SegurancaCorre.gameObject.SetActive(true);
            TiSeba.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Seguidor.Ataca = false;

            SegurancaDouglas.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            SegurancaGordo.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            SegurancaJovem.gameObject.GetComponent<CapsuleCollider>().enabled = false;

            //Invoke("ActivaSeguranca", 1f);

            PanelIlustracao.SetActive(true);
            ColisorI.gameObject.SetActive(true);

            Destroy(this.gameObject);
        }
    }

}
