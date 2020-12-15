using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseVolume : MonoBehaviour
{
    [SerializeField]Slider mySound = null;
    [SerializeField]Slider mySfx = null;
    public void ChangeVolumeSfx()
    {
        AkSoundEngine.SetRTPCValue("sfxVolume", mySfx.value * 100);
    }
    public void ChangeVolumeMusic()
    {
        AkSoundEngine.SetRTPCValue("musicVolume", mySound.value * 100);
    }
}
