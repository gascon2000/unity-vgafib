using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //public Buttons button;
    public GameObject menu;
    public void Button_Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void Button_Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //public void Button_Click()
    //{
    //    if (button.gameObject.tag=="Button_R") Button_Resume();
    //}

    //public void Button_AnotherClick(int bt)
    //{
    //    switch (bt)
    //    {
    //        case 0:
    //            Button_Resume();
    //            break;
    //        case 1:
    //            Button_Resume();
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
