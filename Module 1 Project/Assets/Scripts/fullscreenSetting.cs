using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreenSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetFullScren (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }  
}
