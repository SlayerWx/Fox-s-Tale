using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseVolume : MonoBehaviour
{
    [SerializeField]Slider mySound = null;
    [SerializeField]Slider mySfx = null;
    public static float actualValueSfx = 0.5f;
    public static float actualValueMusic = 0.5f;
    private void Start()
    {
        mySfx.value = actualValueSfx;
        mySound.value = actualValueMusic;
    }
    public void ChangeVolumeSfx()
    {
        AkSoundEngine.SetRTPCValue("sfxVolume", mySfx.value * 100);
        actualValueSfx = mySfx.value;
    }
    public void ChangeVolumeMusic()
    {
        AkSoundEngine.SetRTPCValue("musicVolume", mySound.value * 100);
        actualValueMusic = mySound.value;
    }
}
