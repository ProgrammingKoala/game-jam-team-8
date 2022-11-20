using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaidingPanel : MonoBehaviour
{
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image= GetComponent<Image>();
        _image.color = Color.clear;
    }

   private void changeSceneAnim()
    {
        StartCoroutine(aaaa());
    }

    private IEnumerator aaaa()
    {
        float a = 0;
        while (a < 1)
        {
            _image.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.03f);
            a += 0.01f;
        }
        _image.color = Color.clear;
    }


    private void OnEnable()
    {
        GameEvents.onSceneChange += changeSceneAnim;
    }

    private void OnDisable()
    {
        GameEvents.onSceneChange -= changeSceneAnim;
    }

}
