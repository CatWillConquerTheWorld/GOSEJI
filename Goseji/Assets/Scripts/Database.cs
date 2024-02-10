using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Database : MonoBehaviour
{
    public string userFilePath; // ��� string ����
    public string catFilePath;
    public string itemFilePath;

    [Serializable]
    public class User // ���� Ŭ����
    {
        public string userName;
        public int hp;
        public int mental;
        public int money;
        public int remainBehave;

        public Cat[] myCats; // ������ �ִ� ����̵��� ����Ʈ

        public User(string _userName, int _hp, int _mental, int _money)
        {
            userName = _userName;
            hp = _hp;
            mental = _mental;
            money = _money;
            remainBehave = 7;
            myCats = new Cat[10]; // ���� �� �ִ� ����̴� �ִ� 10����
        }
    }

    [Serializable]
    public class Cat // ����� Ŭ����
    {
        public string catName;
        public string catType;
        public int hp;
        public int hogamdo;
        public int hogamchi;
        public int hungry;

        public Cat(string _catName, string _catType, int _hp, int _hogamdo, int _hogamchi, int _hungry)
        {
            catName = _catName;
            catType = _catType;
            hp = _hp;
            hogamdo = _hogamdo;
            hogamchi = _hogamchi;
            hungry = _hungry;
        }
    }

    [Serializable]
    public class Item // ������ Ŭ����
    {
        public string itemName;
        public string itemType;
        public int effect;

        public Item(string _itemName, string _itemType, int _effect)
        {
            itemName = _itemName;
            itemType = _itemType;
            effect = _effect;
        }
    }

    [Serializable]
    public class Cats // ����̵��� ���� �����̳�
    {
        public Cat[] catList;
    }

    [Serializable]
    public class Items // �����۵��� ���� �����̳�
    {
        public Item[] itemList;
    }

    public User user; // �⺻ ��ü�� ����
    public Cats cats;
    public Items items;

    void Awake() // ���� ��� ����, Awake���� �ϴ� ������ Application.persistentDataPath�� �Լ� �ܿ��� ���ǽ� ���� �߻�.
    {
        userFilePath = Application.persistentDataPath + "/user.json"; // ���� ��� : C:/Users/����� �̸�/AppData/LcoalLow/CatWilConquerTheWorld/Goseji/~~~.json
        catFilePath = Application.persistentDataPath + "/cat.json";
        itemFilePath = Application.persistentDataPath + "/item.json";
    }

    public void SaveData(string type) // ������ �����ϴ� ������ �Լ�
    {
        switch(type)
        {
            case "user": // �Է¹��� ���ڿ��� "user" ���
                SaveUserData(); break; // ���� ���� ����
            case "cat": // "cat"�̶��
                SaveCatData(); break; // ����� ���� ����
            case "item": // "item"�̶�� 
                SaveItemData(); break; // ������ ���� ����
            case "all": // "all" �̶��
                SaveUserData(); // ��� ����
                SaveCatData();
                SaveItemData();
                break;
        }
    }

    public void LoadData(string type) // ������ �ҷ����� ������ �Լ�, ����� ���� ����.
    {
        switch (type)
        {
            case "user":
                LoadUserData(); break;
            case "cat":
                LoadCatData(); break;
            case "item":
                LoadItemData(); break;
            case "all":
                LoadUserData();
                LoadCatData();
                LoadItemData();
                break;
        }
    }

    public void SaveUserData() // ���� ������ �����ϴ� �Լ�
    {
        string jsonData = JsonUtility.ToJson(user, true); // JsonUtility.ToJson => ��ü�� Json���ڿ��� �ٲ���, �� ��° ���� true�� ���� �̻ڰ� ���ִ� ���
        File.WriteAllText(userFilePath, jsonData); // File.WriteAllText => ������ ��ο� ���ڷ� ���� ���ڿ� ����
    }

    public void LoadUserData() // ���� ������ �ҷ����� �Լ�
    {
        if (!File.Exists(userFilePath)) // ���� ��λ� ������ ���ٸ�
        {
            Debug.Log("������ �����ϴ�."); // ����ó��
        }
        else
        {
            string jsonData = File.ReadAllText(userFilePath); // File.ReadAllText => ������ ��ο� �ִ� ������ ��� �о��
            user = JsonUtility.FromJson<User>(jsonData); // Json.FromJson<Ŭ����> => �о�� ���ڿ��� �ش� Ŭ������ �ٲ���. �̸� �����ص� ��ü�� ���� ����
        }
    }

    // Load �Ŀ��� ����Ƽ ��ũ��Ʈ ������ �����Ӱ� ����� ������.

    public void SaveCatData()
    {
        string jsonData = JsonUtility.ToJson(cats, true);
        File.WriteAllText(catFilePath, jsonData);
    }

    public void LoadCatData()
    {
        if (!File.Exists(catFilePath))
        {
            Debug.Log("������ �����ϴ�.");
        }
        else
        {
            string jsonData = File.ReadAllText(catFilePath);
            cats = JsonUtility.FromJson<Cats>(jsonData);
        }
    }

    public void SaveItemData()
    {
        string jsonData = JsonUtility.ToJson(items, true);
        File.WriteAllText (itemFilePath, jsonData);
    }

    public void LoadItemData()
    {
        if (!File.Exists(itemFilePath))
        {
            Debug.Log("������ �����ϴ�.");
        }
        else
        {
            string jsonData = File.ReadAllText(itemFilePath);
            items = JsonUtility.FromJson<Items>(jsonData);
        }
    }

    public void Init() // ���� ����� ���� ���� �Լ�
    {
        User user = new User("�̿��� �����", 100, 1000, 10000); // �ű� ����

        Cat song = new Cat("����", "�����̳� �����", 100, 0, 0, 20); // �ű� �����
        Cat mechNyan = new Cat("���̺��׳�", "��������", 200, 0, 0, 10);

        cats.catList = new Cat[] { song, mechNyan }; // �ű� ����̵� ����Ʈ�� ����

        Item churr = new Item("��", "��赵 �϶�", 10); // �ű� ������
        Item catnip = new Item("Ĺ��", "��赵 �϶�", 15);

        items.itemList = new Item[] { churr, catnip }; // �ű� �����۵� ����Ʈ�� ����

        SaveData("all"); // ��� ���� �� �ҷ�����
        LoadData("all");
    }

    void Start()
    {
        Init();
    }
}
