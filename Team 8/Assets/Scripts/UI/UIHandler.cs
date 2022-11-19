using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneConsts.MENU);
    }

    public void Exit()
    {
        Application.Quit();
    } 
}
