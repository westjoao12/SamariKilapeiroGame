using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPVoltando : MonoBehaviour
{

    public GameObject Seguranca;
    public GameObject SegurancaPri;

    public GameObject[] Carteiras;


    //public GameObject Pessoas;

    public GameObject[] Sanitas;

    public GameObject[] ComputadorMesa;

    public GameObject ColisorDescendo;

    public GameObject Indicador;

    //Primeiro Piso

    public GameObject[] CarteirasPri;

    //public GameObject PessoasPri;

    public GameObject[] SanitasPri;


    string MissaoActual;

    void Start()
    {
        MissaoActual = GameManager.MissaoActual;
    }


    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {

            if ((MissaoActual == "expermento") || (MissaoActual == "expermentoEP"))
            {
                Seguranca.gameObject.SetActive(false);
            }
            else
            {
                Seguranca.gameObject.SetActive(true);
                SegurancaPri.gameObject.SetActive(false);
            }



            for (int i = 0; i < Carteiras.Length; i++)
            {
                Carteiras[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < Sanitas.Length; i++)
            {
                Sanitas[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < ComputadorMesa.Length; i++)
            {
                ComputadorMesa[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < CarteirasPri.Length; i++)
            {
                CarteirasPri[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < SanitasPri.Length; i++)
            {
                SanitasPri[i].gameObject.SetActive(false);
            }

            Indicador.gameObject.SetActive(true);
            ColisorDescendo.gameObject.SetActive(true);

            this.gameObject.SetActive(false);

        }
    }
}
