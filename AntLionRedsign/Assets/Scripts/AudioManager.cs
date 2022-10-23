
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] AudioMixer mixer;
    
    public const string SFX_KEY = "sfxVolume"; 

    void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        LoadVolume(); 
    }

    void LoadVolume(){
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume)*20);

    }

    public void Silence(){
        mixer.SetFloat(VolumeSettings.MIXER_SFX, 0.0001f); 
    }
}
