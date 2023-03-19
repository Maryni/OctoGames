using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIActions : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void ChangeStateVisible()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
