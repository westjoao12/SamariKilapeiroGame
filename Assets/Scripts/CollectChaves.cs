using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectChaves : MonoBehaviour {

	private int Totalchaves =0;

	public Text chaves;

	private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Chaves"))
        {                               
            Totalchaves +=1;
            chaves.text =Totalchaves.ToString();

            GameManager.chavesalvo = GameManager.chavesalvo + 1;

            PlayerPrefs.SetInt("chavesalvo", GameManager.chavesalvo);
            
        }
    }

    void Update()
    {
        GameManager.chave = Totalchaves;
    }
}
