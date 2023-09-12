using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaVolume : MonoBehaviour
{

    float volumeAqui;
    float volumeAquiMusica;
    public Slider SliderVolume;
    public Slider SliderMusica;

    GameObject[] Musicas;

    public GameObject ImagemVolumeMax;
    public GameObject ImagemVolumeMin;

    public GameObject ImagemVolumeMuMax;
    public GameObject ImagemVolumeMuMin;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = GameManager.VOLUME;
        SliderVolume.value = PlayerPrefs.GetFloat("Slider");
        SliderMusica.value = PlayerPrefs.GetFloat("SliderMusica");

        Musicas = GameObject.FindGameObjectsWithTag("MainCamera");
        for (int i = 0; i < Musicas.Length; i++)
        {
           // Musicas[i].GetComponent<AudioSource>().volume = GameManager.VolumeMusica;
            Musicas[i].GetComponent<AudioSource>().volume = GameManager.VolumeMusica;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        VolumeMaster(SliderVolume.value);
        VolumeMusica(SliderMusica.value);
    }

    public void VolumeMaster(float volume)
    {
        volumeAqui = volume;

        GameManager.VOLUME = volumeAqui;

        PlayerPrefs.SetFloat("VOLUME", GameManager.VOLUME);

        AudioListener.volume = volumeAqui;


        PlayerPrefs.SetFloat("Slider", volumeAqui);

        //SliderVolume.value = GameManager.VOLUME;

        if (SliderVolume.value == 0)
        {
            ImagemVolumeMin.SetActive(true);
            ImagemVolumeMax.SetActive(false);

        }
        else if(SliderVolume.value!=0)
        {
            ImagemVolumeMax.SetActive(true);
            ImagemVolumeMin.SetActive(false);
        }



    }

    public void VolumeMusica(float volume)
    {
        volumeAquiMusica = volume;

        GameManager.VolumeMusica = volumeAquiMusica;

        PlayerPrefs.SetFloat("VolumeMusica", GameManager.VolumeMusica);

        Musicas = GameObject.FindGameObjectsWithTag("MainCamera");
        for (int i = 0; i < Musicas.Length; i++)
        {
            Musicas[i].GetComponent<AudioSource>().volume = volumeAquiMusica;

        }

        PlayerPrefs.SetFloat("SliderMusica", volumeAquiMusica);

        //SliderVolume.value = GameManager.VOLUME;

        if (SliderMusica.value == 0)
        {
            ImagemVolumeMuMin.SetActive(true);
            ImagemVolumeMuMax.SetActive(false);

        }
        else if (SliderMusica.value != 0)
        {
            ImagemVolumeMuMax.SetActive(true);
            ImagemVolumeMuMin.SetActive(false);
        }



    }
}
