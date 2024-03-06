using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { 
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (_instance == null)
                {
                    Debug.Log("no singleton obj");
                }
            }
            return _instance; 
        }
    }

    public int money;
    public int mental;
    public int HP;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // 게임매니저의 변수 및 함수 사용법 - 자신이 사용하는 스크립트에서 게임매니저의 원하는 변수/함수를 사용하려면
    // GameManager.Instance.~~~ 이런식으로 가져와서 활용 가능~!

    private void Start()
    {
        money = PlayerPrefs.GetInt("money", 500);
        //Debug.Log(money);
    }

    public void chargemoney(int charge_money)
    {
        money += charge_money;
        PlayerPrefs.SetInt("money", money);
        Debug.Log(money);
    }

    public void getmoney()
    {
        int mymoney = PlayerPrefs.GetInt("money", 500);
        Debug.Log(mymoney);
    }

}
