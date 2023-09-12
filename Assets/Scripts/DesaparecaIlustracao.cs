using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesaparecaIlustracao : MonoBehaviour
{
    public GameObject PanelIlustracao;
    public GameObject Porta2;
    public Text textoIlustracao;

    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {
            DesaparecaIlustra();
            Porta2.gameObject.SetActive(true);
            Destroy(this.gameObject);

        }
    }

    public void DesaparecaIlustra()
    {
        PanelIlustracao.SetActive(false);
        textoIlustracao.text = "";
    }
}
