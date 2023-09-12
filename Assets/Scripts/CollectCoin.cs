using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
    private int coinvault = 0;

    public Text score;

    public Text textoIlustracao;
    public GameObject PanelIlustracao;

    public GameObject chaveResChao;
    public GameObject chavePrimeiro;
    public GameObject chaveSegundo;

    private void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject.CompareTag("Moeda"))
        {
            Destroy(objeto.gameObject);
            coinvault += 1;
            score.text = coinvault.ToString();
            //Debug.Log(coinvault);

            GameManager.livrosalvo = GameManager.livrosalvo + 1;

            PlayerPrefs.SetInt("livrosalvo", GameManager.livrosalvo);

            GetComponent<AudioSource>().Play();

            if (coinvault == 45)
            {
                chaveResChao.gameObject.SetActive(true);

                AparecaIlustracao("Agora encontre a chave no centro do pátio.");
                Invoke("DesaparecaIlustracao",4f);
                

            }
            if (coinvault == 95)
            {
                chavePrimeiro.gameObject.SetActive(true);

                AparecaIlustracao("Agora encontre a 2ª chave no 1º piso, onde tem o dizer do SOCRATES.");
                Invoke("DesaparecaIlustracao", 4f);


            }
            if (coinvault == 155)
            {
                chaveSegundo.gameObject.SetActive(true);

                AparecaIlustracao("Agora encontre a 3ª chave no 2º piso, na ultima sala antes do laboratório.");
                Invoke("DesaparecaIlustracao", 4f);
            }
        }
    }

    public void AparecaIlustracao(string texto)
    {
        textoIlustracao.text = texto;
        PanelIlustracao.SetActive(true);  
    }
    public void DesaparecaIlustracao()
    {
        PanelIlustracao.SetActive(false);
        textoIlustracao.text = "";
    }


    void Update()
    {
        GameManager.livro = coinvault;
    }
}
