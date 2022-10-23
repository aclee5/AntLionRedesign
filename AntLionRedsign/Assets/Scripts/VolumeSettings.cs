
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider sfxSlider;

    public const string MIXER_SFX = "SFXVolume";

    void Awake(){
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    void Start(){
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY,1f); 
    }

    void OnDisable(){
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }

    void SetSFXVolume(float value){
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value)*20);
    } 

    
}
