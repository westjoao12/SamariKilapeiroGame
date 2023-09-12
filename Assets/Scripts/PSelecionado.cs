using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PSelecionado : MonoBehaviour
{

    public GameObject Esperanca;
    public GameObject Samari;

    public GameObject Luz;

    public GameObject[] Segurancas;

    int CharacterSelecionado = 0;
    string MissaoActual;

    // Start is called before the first frame update
    void Awake()
    {        
        CharacterSelecionado = GameManager.CharactersIndex;
        MissaoActual = GameManager.MissaoActual;

        #region PersonagemActivo
        if (CharacterSelecionado == 0)
        {
            Esperanca.gameObject.SetActive(true);
            Samari.gameObject.SetActive(false);
        }
        else if (CharacterSelecionado == 1)
        {
            Samari.gameObject.SetActive(true);
            Esperanca.gameObject.SetActive(false);
        }
        #endregion

        #region MissaoActual
        if(MissaoActual == "informatica")
        {
            for(int i = 0; i < Segurancas.Length; i++)
            {
                Segurancas[i].gameObject.SetActive(true);         
            }

            Luz.gameObject.SetActive(false);
        }
        else if(MissaoActual == "expermento")
        {
            for (int i = 0; i < Segurancas.Length; i++)
            {
                Segurancas[i].gameObject.SetActive(false);     
            }
            Luz.gameObject.SetActive(false);
        }
        else if(MissaoActual== "periodo")
        {
            for (int i = 0; i < Segurancas.Length; i++)
            {
                Segurancas[i].gameObject.SetActive(true);
            }

            Luz.gameObject.SetActive(true);
        }
        #endregion



    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }   
}
