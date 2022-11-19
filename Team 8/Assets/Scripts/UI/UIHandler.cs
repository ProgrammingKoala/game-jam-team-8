using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneConsts.MENU);
    }
    public void LoadInstractions()
    {
        SceneManager.LoadScene(SceneConsts.INSTRUCTIONS);
    }
    public void LoadCreators()
    {
        SceneManager.LoadScene(SceneConsts.CREATORS);
    }

    public void LoadLevel1_1()
    {
        SceneManager.LoadScene(SceneConsts.LEVEL1_1);
    }
    public void Exit()
    {
        Application.Quit();
    } 
}
