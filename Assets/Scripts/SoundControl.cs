using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SoundControl : MonoBehaviour
{
    public Slider gameSoundSlider;
    public Slider vfxSoundSlider;
    public AudioMixer gameSounds;
    public AudioMixer vfxSounds;
    public static SoundControl instance;
    float soundVolume;
    float vfxVolume;


    void Awake()
    {
        instance = this;
        gameSoundSlider.onValueChanged.AddListener(GameSoundVolumeChange);
        vfxSoundSlider.onValueChanged.AddListener(VfxSoundVolumeChange);
        gameSounds.GetFloat("Volume",out soundVolume);
        vfxSounds.GetFloat("Volume", out vfxVolume);
        SliderUpdate();
        
    }
    void SliderUpdate()
    {
        gameSoundSlider.value = soundVolume;
        vfxSoundSlider.value = vfxVolume;
    }

    public void DefaultSounds(float sound,float vfx)
    {
        gameSounds.SetFloat("Volume", sound);
        vfxSounds.SetFloat("Volume", vfx);
        gameSoundSlider.value = sound;
        vfxSoundSlider.value = vfx;
    }
    void GameSoundVolumeChange(float value)
    {
        gameSounds.SetFloat("Volume", value);
    }
    void VfxSoundVolumeChange(float value)
    {
        vfxSounds.SetFloat("Volume", value);
    }
    public void ReturnGame()
    {
        PauseControl.pauseMenuShow = true;
        Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync("PauseScene");
    }


}
