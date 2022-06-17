using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SoundControl : MonoBehaviour
{
    public Slider gameSoundSlider;
    public Slider vfxSoundSlider;
    public AudioMixer gameSounds;
    public AudioMixer vfxSounds;
    public static SoundControl instance;
    void Start()
    {
        instance = this;
        gameSoundSlider.onValueChanged.AddListener(GameSoundVolumeChange);
        vfxSoundSlider.onValueChanged.AddListener(VfxSoundVolumeChange);
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


}
