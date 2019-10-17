using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SelectLevel()
    {
        SceneManager.LoadScene("Level");
    }
	
	public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
	
	public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
	
    public void ReturntoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
	
    public void Quit()
    {
        Application.Quit();
    }
}
