using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectFixa : MonoBehaviour {

    private int Totalfixa = 0;

    public Text fixa;


    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Fixa"))
        {
            Totalfixa += 1;
            fixa.text = Totalfixa.ToString();

            GameManager.fixasalva = GameManager.fixasalva + 1;

            PlayerPrefs.SetInt("fixasalva", GameManager.fixasalva);
            
        }
    }


    void Update ()
    {
        GameManager.Fixa = Totalfixa;
    }
}
