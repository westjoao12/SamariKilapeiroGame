using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PanelMenuPausa;
    public GameObject BotaoPausa;
    public GameObject PanelChLiFi;
    public GameObject PanelNavegacao;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            PanelMenuPausa.SetActive(true);
            BotaoPausa.SetActive(false);
            PanelChLiFi.SetActive(false);
            PanelNavegacao.SetActive(false);
            Time.timeScale = 0f;
        }
    }


    public void Resume()
    {
        PanelMenuPausa.SetActive(false);
        BotaoPausa.SetActive(true);
        PanelChLiFi.SetActive(true);
        PanelNavegacao.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PanelMenuPausa.SetActive(true);
        BotaoPausa.SetActive(false);
        PanelChLiFi.SetActive(false);
        PanelNavegacao.SetActive(false);
        Time.timeScale = 0f; 
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        GameManager.gm.chamaMenu();
    }

    public void Loja()
    {
        //Time.timeScale = 1f;
        GameManager.gm.Loja();
    }

    public void Sair()
    {
        Application.Quit();
    }
}
