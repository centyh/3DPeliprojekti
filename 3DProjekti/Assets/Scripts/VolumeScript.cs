using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;


    private void Start()
    {
        LoadValue();
    }

    //public void VolumeSlider(float volume)
    //{
    //    volumeTextUI.text = volume.ToString("0,0");
    //}

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValue();
    }

    void LoadValue()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }



}
