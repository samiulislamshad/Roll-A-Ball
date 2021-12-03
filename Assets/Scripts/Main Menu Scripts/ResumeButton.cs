using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject ScorePanel;
    [SerializeField] private GameObject OptionPanel;
    void Start()
    {
        
    }

    public void OnClickResumeButton()
    {
        OptionPanel.SetActive(false);
        ScorePanel.SetActive(true);
        Time.timeScale = 1;
    }
}
