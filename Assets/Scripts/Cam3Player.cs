using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam3Player : MonoBehaviour
{
    public GameObject cabeca;
    public GameObject CabecaSamari;
    public GameObject[] posicoes;
    public GameObject[] posicoesSamari;
    public int indice = 0;
    public float velocidadeDeMovimento = 2;
    private RaycastHit hit;

    int CharacterSelecionado = 0;

    void Awake()
    {
        CharacterSelecionado = GameManager.CharactersIndex;
    }

    void FixedUpdate()
    {

        if (CharacterSelecionado == 0)
        {
            transform.LookAt(cabeca.transform);
            // checar se tem colisor
            if (!Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position))
            {
                transform.position = Vector3.Lerp(transform.position, posicoes[indice].transform.position, velocidadeDeMovimento * Time.deltaTime);
                Debug.DrawLine(cabeca.transform.position, posicoes[indice].transform.position);
            }
            else if (Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position, out hit))
            {
                transform.position = Vector3.Lerp(transform.position, hit.point, (velocidadeDeMovimento * 2) * Time.deltaTime);
                Debug.DrawLine(cabeca.transform.position, hit.point);
            }
        }
        else if (CharacterSelecionado == 1)
        {
            transform.LookAt(CabecaSamari.transform);
            // checar se tem colisor
            if (!Physics.Linecast(CabecaSamari.transform.position, posicoesSamari[indice].transform.position))
            {
                transform.position = Vector3.Lerp(transform.position, posicoesSamari[indice].transform.position, velocidadeDeMovimento * Time.deltaTime);
                Debug.DrawLine(CabecaSamari.transform.position, posicoesSamari[indice].transform.position);
            }
            else if (Physics.Linecast(CabecaSamari.transform.position, posicoesSamari[indice].transform.position, out hit))
            {
                transform.position = Vector3.Lerp(transform.position, hit.point, (velocidadeDeMovimento * 2) * Time.deltaTime);
                Debug.DrawLine(CabecaSamari.transform.position, hit.point);
            }
        }

        
    }
    void Update()
    {
        if (CharacterSelecionado == 0)
        {
            if (Input.GetKeyDown("e") && indice < (posicoes.Length - 1))
            {
                indice++;
            }
            else if (Input.GetKeyDown("e") && indice >= (posicoes.Length - 1))
            {
                indice = 0;
            }
        }
        else if (CharacterSelecionado == 1)
        {
            if (Input.GetKeyDown("e") && indice < (posicoesSamari.Length - 1))
            {
                indice++;
            }
            else if (Input.GetKeyDown("e") && indice >= (posicoesSamari.Length - 1))
            {
                indice = 0;
            }
        }


        
    }

    public void MudarPosicaoCamera()
    {
        if (CharacterSelecionado == 0)
        {
            if (indice < (posicoes.Length - 1))
            {
                indice++;
            }
            else if (indice >= (posicoes.Length - 1))
            {
                indice = 0;
            }
        }
        else if (CharacterSelecionado == 1)
        {
            if (indice < (posicoesSamari.Length - 1))
            {
                indice++;
            }
            else if (indice >= (posicoesSamari.Length - 1))
            {
                indice = 0;
            }
        }
        
    }
}
