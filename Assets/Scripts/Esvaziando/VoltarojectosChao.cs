using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltarojectosChao : MonoBehaviour
{
    public GameObject Seguranca;

    public GameObject[] Carteiras;

    //public GameObject Pessoas;

    //public GameObject Secretarias;

    //public GameObject Professores;

    public GameObject[] Sanita;

    public GameObject[] Estintores;

    public GameObject ColisorAoDescer;


    string MissaoActual;

    void Start()
    {
        MissaoActual = GameManager.MissaoActual;
    }


    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {

            //if (MissaoActual != "expermento")
            //{
            //    Seguranca.gameObject.SetActive(true);
            //}
            //else
            //{
            //    Seguranca.gameObject.SetActive(false);
            //}



            if((MissaoActual== "expermento")||(MissaoActual== "expermentoEP"))
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

            for (int i = 0; i < Sanita.Length; i++)
            {
                Sanita[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < Estintores.Length; i++)
            {
                Estintores[i].gameObject.SetActive(true);
            }

            //Pessoas.gameObject.SetActive(true);

            //Secretarias.gameObject.SetActive(true);

            //Professores.gameObject.SetActive(true);

            ColisorAoDescer.gameObject.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
}
