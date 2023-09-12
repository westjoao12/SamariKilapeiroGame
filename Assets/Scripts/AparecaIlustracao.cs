using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AparecaIlustracao : MonoBehaviour
{
    public GameObject PanelIlustracao;
    public GameObject ColisorI;
    public Text textoIlustracao;

    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {
            AparecaIlustra("Desça até a sala das Finanças.");
            ColisorI.gameObject.SetActive(true);

        }
    }

    public void AparecaIlustra(string texto)
    {
        textoIlustracao.text = texto;
        PanelIlustracao.SetActive(true);
    }

}
