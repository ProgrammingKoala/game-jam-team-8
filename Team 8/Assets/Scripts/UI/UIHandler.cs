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
    public void Exit()
    {
        Application.Quit();
    } 
}
