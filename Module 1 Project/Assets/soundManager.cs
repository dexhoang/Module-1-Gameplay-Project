using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//help from https://youtu.be/yWCHaTwVblk?si=kqdsdhFYbay_Uue3

public class soundManager : MonoBehaviour
{
    [SerializeField] Slider soundSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = soundSlider.value;
        Save();
    }
    
    private void Load()
    {
        soundSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", soundSlider.value);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
