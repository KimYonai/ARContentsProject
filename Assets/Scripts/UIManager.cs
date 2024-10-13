using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

    private GameObject pauseWindow;

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
    }

    private void Start()
    {
        pauseWindow = GameObject.Find("PauseWindow");
        pauseWindow.SetActive(false);
    }

    public void OnPauseButton()
    {
        pauseWindow.SetActive(true);
    }

    public void OnBackButton()
    {
        pauseWindow.SetActive(false);
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
