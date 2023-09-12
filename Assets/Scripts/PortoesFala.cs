using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortoesFala : MonoBehaviour
{

    public GameObject PanelIlustracao;
    public Text texto;

    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {

            texto.text = "   Volte depois de conseguires a chave.";
            PanelIlustracao.SetActive(true);


        }

    }

    private void OnCollisionExit(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {
            PanelIlustracao.SetActive(false);
        }

    }
}
