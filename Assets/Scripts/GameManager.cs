using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;


    private MissionBase[] missions;
    private MissionBaseEP[] missionsEP;

    private AudioListener[] AudioListeners;
    public static float VOLUME = 0.716988f;

    GameObject[] Musicas;
    public static float VolumeMusica = 0.4444973f;

    // private AudioSource[] Audio;

    public static int livrosalvo = 0;
    public static int chavesalvo = 0;
    public static int fixasalva = 0;
    public static int CharactersIndex = 0;
    public static string nomeusuario = "Eu";
    public static string MissaoProvaCFB = "false";
    public static string MissaoPeriodoManha = "false";
    public static string MissaoPeriodoManhaEP = "false";
    public static string PersonagemSamari = "false";

    public static int livro = 0;
    public static int chave = 0;
    public static int Fixa = 0;

    public static int ValorRecompensa = 0;
    public static string MissaoActual = "informatica";

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else if (gm != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        #region Instacia Os Minutos do Saber
        missions = new MissionBase[1];

        for(int i = 0; i < missions.Length; i++)
        {
            GameObject newMission = new GameObject("Mission" + i);
            newMission.transform.SetParent(transform);
            MissionType[] missionType = { MissionType.Informatica, MissionType.Programacao };
            int randomType = Random.Range(0, missionType.Length);

            if(randomType== (int)MissionType.Informatica)
            {
                missions[i] = newMission.AddComponent<Informatica>();
            }
            else if(randomType == (int)MissionType.Programacao)
            {
                missions[i] = newMission.AddComponent<Programacao>();
            }
            missions[i].Created();
        }
        #endregion

        #region Instacia Os Minutos do Saber EP
        missionsEP = new MissionBaseEP[1];

        for (int i = 0; i < missionsEP.Length; i++)
        {
            GameObject newMissionEP = new GameObject("MissionEP" + i);
            newMissionEP.transform.SetParent(transform);
            MissionTypeEP[] missionTypeEP = { MissionTypeEP.Geral, MissionTypeEP.Historia };
            int randomTypeEP = Random.Range(0, missionTypeEP.Length);

            if (randomTypeEP == (int)MissionTypeEP.Geral)
            {
                missionsEP[i] = newMissionEP.AddComponent<Geral>();
            }
            else if (randomTypeEP == (int)MissionTypeEP.Historia)
            {
                missionsEP[i] = newMissionEP.AddComponent<Historia>();
            }
            missionsEP[i].CreatedEP();
        }
        #endregion

    }


    // Use this for initialization
    void Start()
    {
        #region SalvaLivro
        if (PlayerPrefs.HasKey("livrosalvo"))
        {
            livrosalvo = PlayerPrefs.GetInt("livrosalvo");
        }
        else
        {
            PlayerPrefs.SetInt("livrosalvo", livrosalvo);
        }
        #endregion

        #region SalvaChave
        if (PlayerPrefs.HasKey("chavesalvo"))
        {
            chavesalvo = PlayerPrefs.GetInt("chavesalvo");
        }
        else
        {
            PlayerPrefs.SetInt("chavesalvo", chavesalvo);
        }
        #endregion

        #region SalvaFixa

        if (PlayerPrefs.HasKey("fixasalva"))
        {
            fixasalva = PlayerPrefs.GetInt("fixasalva");
        }
        else
        {
            PlayerPrefs.SetInt("fixasalva", fixasalva);
        }
        #endregion

        #region Salva nome do usuario
        if (PlayerPrefs.HasKey("nomeusuario"))
        {
            nomeusuario = PlayerPrefs.GetString("nomeusuario");
        }
        else
        {
            PlayerPrefs.SetString("nomeusuario", nomeusuario);
        }

        #endregion

        #region Salva Volume

        if (PlayerPrefs.HasKey("VOLUME"))
        {
            VOLUME = PlayerPrefs.GetFloat("VOLUME");
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUME", VOLUME);
        }
        #endregion

        #region Salva Volume da musica

        if (PlayerPrefs.HasKey("VolumeMusica"))
        {
            VolumeMusica = PlayerPrefs.GetFloat("VolumeMusica");
        }
        else
        {
            PlayerPrefs.SetFloat("VolumeMusica", VolumeMusica);
        }
        #endregion

        #region Salva Missao Prova CFB
        if (PlayerPrefs.HasKey("MissaoProvaCFB"))
        {
            MissaoProvaCFB = PlayerPrefs.GetString("MissaoProvaCFB");
        }
        else
        {
            PlayerPrefs.SetString("MissaoProvaCFB", MissaoProvaCFB);
        }
        #endregion

        #region Salva Missao Periodo Manha
        if (PlayerPrefs.HasKey("MissaoPeriodoManha"))
        {
            MissaoPeriodoManha = PlayerPrefs.GetString("MissaoPeriodoManha");
        }
        else
        {
            PlayerPrefs.SetString("MissaoPeriodoManha", MissaoPeriodoManha);
        }
        #endregion

        #region Salva Missao Periodo Manha EP
        if (PlayerPrefs.HasKey("MissaoPeriodoManhaEP"))
        {
            MissaoPeriodoManhaEP = PlayerPrefs.GetString("MissaoPeriodoManhaEP");
        }
        else
        {
            PlayerPrefs.SetString("MissaoPeriodoManhaEP", MissaoPeriodoManhaEP);
        }
        #endregion

        #region Salva Personagem Samari
        if (PlayerPrefs.HasKey("PersonagemSamari"))
        {
            PersonagemSamari = PlayerPrefs.GetString("PersonagemSamari");
        }
        else
        {
            PlayerPrefs.SetString("PersonagemSamari", PersonagemSamari);
        }
        #endregion

        #region Salva Personagem Selecionado
        if (PlayerPrefs.HasKey("CharactersIndex"))
        {
            CharactersIndex = PlayerPrefs.GetInt("CharactersIndex");
        }
        else
        {
            PlayerPrefs.SetInt("CharactersIndex", CharactersIndex);
        }
        #endregion

        Debug.Log("Livros:"+livrosalvo+ " Chaves:" + chavesalvo + " Fixa:" + fixasalva + " Pessoa:"+CharactersIndex+" Missoa:"+MissaoActual);
        

    }

    // Update is called once per frame
    void Update()
    {
        #region Poe musica e volume em toda cena
        if (Application.loadedLevelName != "Menu")
        {

            AudioListeners = GameObject.FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
            AudioListener.volume = VOLUME;



            Musicas = GameObject.FindGameObjectsWithTag("MainCamera") as GameObject[];
            for (int i = 0; i < Musicas.Length; i++)
            {
                Musicas[i].GetComponent<AudioSource>().volume = VolumeMusica;

            }
            Destroy(gameObject);
            //Audio = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            //AudioSource.FindObjectOfType<AudioSource>().volume = VolumeMusica;
            //Destroy(gameObject);
        }
        #endregion

    }

    public void ComecaJogoLab()
    {
        SceneManager.LoadScene("Escola");
    }

    public void ComecaJogoEscPrv()
    {
        SceneManager.LoadScene("EscolaProva");
    }


    public void chamaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Loja()
    {
        SceneManager.LoadScene("Loja");
    }

    public MissionBase GetMission(int index)
    {
        return missions[index];
    }

    public MissionBaseEP GetMissionEP(int index)
    {
        return missionsEP[index];
    }
}
