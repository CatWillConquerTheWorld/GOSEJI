using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunButton : MonoBehaviour
{
    public GameObject RunButtonPress;
    public GameObject RunQuestion;
    public GameObject RunCancel;
    public GameObject HouseButton;
    public GameObject ExploreButton;

    private bool isPressing = false;
    
    
    void Update()
    {
        if (isPressing)
        {
            RunButtonPress.gameObject.SetActive(false);
        }
        else
        {
            RunButtonPress.gameObject.SetActive(true);
        }
        
    }
    
    public void RunPress()
    {
        isPressing = true;
        RunQuestion.gameObject.SetActive(true);
    }

    public void CancelPress()
    {
        isPressing = false;
        RunQuestion.gameObject.SetActive(false);
    }

    public void HousePress()
    {
        //SceneManager.LoadScene("");
    }

    public void ExplorePress()
    {
        SceneManager.LoadScene("Battle");
    }
}
