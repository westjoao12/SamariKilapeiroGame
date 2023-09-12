using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class AumentaVida : MonoBehaviour
{
    public Slider SliderVida;
    public GameObject PanelAumentaVida;
    public GameObject PanelIlustracao;

    public Text textoIlustracao;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision bidom)
    {
        if (bidom.gameObject.CompareTag("Agua"))
        {

            if (SliderVida.value < 3)
            {
                SliderVida.value += 1;
                PanelAumentaVida.SetActive(true);
                Invoke("PanelAumentaV", 2f);

                Destroy(bidom.gameObject);
            }
            else if (SliderVida.value >= 3)
            {
                textoIlustracao.text = "Tens Vida suficiente";
                PanelIlustracao.SetActive(true);
                Invoke("CPanelIlustracao", 1f);
            }
            
        }
    }

    public void PanelAumentaV()
    {
        PanelAumentaVida.SetActive(false);
    }
    public void CPanelIlustracao()
    {
        PanelIlustracao.SetActive(false);
    }
}
