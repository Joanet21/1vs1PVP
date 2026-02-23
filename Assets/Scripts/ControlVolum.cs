using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControlVolum : MonoBehaviour
{
    public AudioMixer mixer;     // Arrossega aquí el MasterMixer
    public Slider sliderVolum;   // Arrossega aquí el SliderVolum

    // IMPORTANT: posa aquí el nom exacta del paràmetre exposat al Mixer
    public string parametreVolum = "Volum";

    void Start()
    {
        // Opcional: posa el volum inicial segons el valor del slider
        CanviarVolum(sliderVolum.value);
    }

    public void CanviarVolum(float valor)
    {
        // Converteix 0..1 a decibels (AudioMixer treballa en dB)
        float db = Mathf.Log10(valor) * 20f;
        mixer.SetFloat(parametreVolum, db);
    }
}