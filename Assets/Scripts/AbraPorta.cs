using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbraPorta : MonoBehaviour
{
    public GameObject[] gate;
    public GameObject Livros;
    public GameObject Bidons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision jogador)
    {
        if (jogador.gameObject.CompareTag("Player"))
        {

            for (int i = 0; i < gate.Length; i++)
            {
                Destroy(gate[i].gameObject);

            }

            Livros.gameObject.SetActive(true);
            Bidons.gameObject.SetActive(true);

            Destroy(this.gameObject);
            //GetComponent<AudioSource>().Play();

        }
    }


}
