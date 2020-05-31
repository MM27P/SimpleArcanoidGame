using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject view1;
    [SerializeField]
    private GameObject view2;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeView1()
    {
        view1.SetActive(true);
        view2.SetActive(false);
    }

    public void ChangeView2()
    {
        view1.SetActive(false);
        view2.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
