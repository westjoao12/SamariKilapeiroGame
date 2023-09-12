using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardarNomeUsuario : MonoBehaviour
{
    public InputField txtNome;
    public Text nomeJogador;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nomeJogador.text = GameManager.nomeusuario;
    }


    public void GuardaNome()
    {
        if(txtNome.text!="")
        {
            GameManager.nomeusuario = txtNome.text;

            PlayerPrefs.SetString("nomeusuario", GameManager.nomeusuario);
 
            txtNome.text = "";
        }
    }
}
