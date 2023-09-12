using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPisoVoltando : MonoBehaviour
{

    public GameObject Seguranca;

    public GameObject[] Carteiras;

    //public GameObject Pessoas;

    public GameObject[] Sanitas;

    public GameObject ColisorDescendo;


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
            }



            for (int i = 0; i < Carteiras.Length; i++)
            {
                Carteiras[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < Sanitas.Length; i++)
            {
                Sanitas[i].gameObject.SetActive(true);
            }

            //Pessoas.gameObject.SetActive(true);
            ColisorDescendo.gameObject.SetActive(true);

            this.gameObject.SetActive(false);

        }
    }

}
