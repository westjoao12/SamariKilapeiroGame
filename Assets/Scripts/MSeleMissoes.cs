using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSeleMissoes : MonoBehaviour
{

    public GameObject[] Missao;
    public int MissaoIndex = 0;

    public Text TextoAvisaLivro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Mudar Missao

    public void ChangeMissao(int index)
    {
        MissaoIndex += index;

        if (MissaoIndex >= Missao.Length)
        {
            MissaoIndex = 0;
        }
        else if (MissaoIndex < 0)
        {
            MissaoIndex = Missao.Length - 1;
        }

        for (int i = 0; i < Missao.Length; i++)
        {
            if (i == MissaoIndex)
            {
                Missao[i].SetActive(true);
                TextoAvisaLivro.text = "";
            }
            else
            {
                Missao[i].SetActive(false);
                TextoAvisaLivro.text = "";
            }
        }
    }

    #endregion
}
