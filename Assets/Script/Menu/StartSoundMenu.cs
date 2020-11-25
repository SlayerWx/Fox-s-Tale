using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoundMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("menuStart", transform.gameObject);
    }
}
