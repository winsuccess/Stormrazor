using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Transform playPanel, guidePanel, settingPanel;

    #region MainPanel
    public void OnClickPlay()
    {
        if(playPanel.gameObject.activeSelf)
            playPanel.gameObject.SetActive(false);
        else
        {
            playPanel.gameObject.SetActive(true);
            guidePanel.gameObject.SetActive(false);
        }

    }

    public void OnClickGuide()
    {
        if (guidePanel.gameObject.activeSelf)
            guidePanel.gameObject.SetActive(false);
        else
        {
            playPanel.gameObject.SetActive(false);
            guidePanel.gameObject.SetActive(true);
        }
    }

    public void OnClickSettings()
    {

    }

    public void OnClickExit()
    {
        
    }
    #endregion

    #region PlayPanel
    public void OnClickSingleplayer()
    {
        GameManager.instance.gameType = "single";
        SceneManager.LoadScene("Ingame");
    }

    public void OnClickMultiplayer()
    {
        GameManager.instance.gameType = "multi";
    }
    #endregion
}
