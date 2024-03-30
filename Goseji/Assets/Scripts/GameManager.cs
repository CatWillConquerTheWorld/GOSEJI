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

    // ���ӸŴ����� ���� �� �Լ� ���� - �ڽ��� ����ϴ� ��ũ��Ʈ���� ���ӸŴ����� ���ϴ� ����/�Լ��� ����Ϸ���
    // GameManager.Instance.~~~ �̷������� �����ͼ� Ȱ�� ����~!

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
