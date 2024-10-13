using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

    private GameObject pauseWindow;

    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider audioSlider;
    [SerializeField] Toggle audioMute;
    [SerializeField] GameObject speaker;

    public static UIManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSlider.onValueChanged.AddListener(SetAudioVolume);
        audioMute.onValueChanged.AddListener(SetAudioMute);
    }

    private void Start()
    {
        pauseWindow = GameObject.Find("PauseWindow");
        pauseWindow.SetActive(false);

        if (PlayerPrefs.HasKey("Volume"))
        {
            audioSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
            audioSlider.value = 0.5f;

        audioMixer.SetFloat("Master", Mathf.Log10(audioSlider.value) * 20);

        speaker.SetActive(true);
    }

    public void OnPauseButton()
    {
        pauseWindow.SetActive(true);
    }

    public void OnBackButton()
    {
        pauseWindow.SetActive(false);
    }

    public void SetAudioVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", audioSlider.value);
    }

    private void SetAudioMute(bool mute)
    {
        AudioListener.volume = (mute ? 0 : 1);
    }

    public void OnQuitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
