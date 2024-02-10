using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Database : MonoBehaviour
{
    public string userFilePath; // 경로 string 선언
    public string catFilePath;
    public string itemFilePath;

    [Serializable]
    public class User // 유저 클래스
    {
        public string userName;
        public int hp;
        public int mental;
        public int money;
        public int remainBehave;

        public Cat[] myCats; // 가지고 있는 고양이들의 리스트

        public User(string _userName, int _hp, int _mental, int _money)
        {
            userName = _userName;
            hp = _hp;
            mental = _mental;
            money = _money;
            remainBehave = 7;
            myCats = new Cat[10]; // 가질 수 있는 고양이는 최대 10마리
        }
    }

    [Serializable]
    public class Cat // 고양이 클래스
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
    public class Item // 아이템 클래스
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
    public class Cats // 고양이들을 담을 컨테이너
    {
        public Cat[] catList;
    }

    [Serializable]
    public class Items // 아이템들을 담을 컨테이너
    {
        public Item[] itemList;
    }

    public User user; // 기본 객체들 생성
    public Cats cats;
    public Items items;

    void Awake() // 파일 경로 지정, Awake에서 하는 이유는 Application.persistentDataPath는 함수 외에서 정의시 오류 발생.
    {
        userFilePath = Application.persistentDataPath + "/user.json"; // 저장 경로 : C:/Users/사용자 이름/AppData/LcoalLow/CatWilConquerTheWorld/Goseji/~~~.json
        catFilePath = Application.persistentDataPath + "/cat.json";
        itemFilePath = Application.persistentDataPath + "/item.json";
    }

    public void SaveData(string type) // 정보를 저장하는 마스터 함수
    {
        switch(type)
        {
            case "user": // 입력받은 문자열이 "user" 라면
                SaveUserData(); break; // 유저 정보 저장
            case "cat": // "cat"이라면
                SaveCatData(); break; // 고양이 정보 저장
            case "item": // "item"이라면 
                SaveItemData(); break; // 아이템 정보 저장
            case "all": // "all" 이라면
                SaveUserData(); // 모두 저장
                SaveCatData();
                SaveItemData();
                break;
        }
    }

    public void LoadData(string type) // 정보를 불러오는 마스터 함수, 저장과 로직 같음.
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

    public void SaveUserData() // 유저 정보를 저장하는 함수
    {
        string jsonData = JsonUtility.ToJson(user, true); // JsonUtility.ToJson => 객체를 Json문자열로 바꿔줌, 두 번째 인자 true는 파일 이쁘게 써주는 기능
        File.WriteAllText(userFilePath, jsonData); // File.WriteAllText => 지정된 경로에 인자로 받은 문자열 저장
    }

    public void LoadUserData() // 유저 정보를 불러오는 함수
    {
        if (!File.Exists(userFilePath)) // 만약 경로상에 파일이 없다면
        {
            Debug.Log("정보가 없습니다."); // 예외처리
        }
        else
        {
            string jsonData = File.ReadAllText(userFilePath); // File.ReadAllText => 지정된 경로에 있는 파일을 모두 읽어옴
            user = JsonUtility.FromJson<User>(jsonData); // Json.FromJson<클래스> => 읽어온 문자열을 해당 클래스로 바꿔줌. 미리 생성해둔 객체에 정보 저장
        }
    }

    // Load 후에는 유니티 스크립트 내에서 자유롭게 사용이 가능함.

    public void SaveCatData()
    {
        string jsonData = JsonUtility.ToJson(cats, true);
        File.WriteAllText(catFilePath, jsonData);
    }

    public void LoadCatData()
    {
        if (!File.Exists(catFilePath))
        {
            Debug.Log("정보가 없습니다.");
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
            Debug.Log("정보가 없습니다.");
        }
        else
        {
            string jsonData = File.ReadAllText(itemFilePath);
            items = JsonUtility.FromJson<Items>(jsonData);
        }
    }

    public void Init() // 최초 실행시 정보 생성 함수
    {
        User user = new User("이웃집 토토로", 100, 1000, 10000); // 신규 유저

        Cat song = new Cat("송이", "지선이네 고양이", 100, 0, 0, 20); // 신규 고양이
        Cat mechNyan = new Cat("사이보그냥", "디지털족", 200, 0, 0, 10);

        cats.catList = new Cat[] { song, mechNyan }; // 신규 고양이들 리스트에 저장

        Item churr = new Item("츄르", "경계도 하락", 10); // 신규 아이템
        Item catnip = new Item("캣닢", "경계도 하락", 15);

        items.itemList = new Item[] { churr, catnip }; // 신규 아이템들 리스트에 저장

        SaveData("all"); // 모두 저장 후 불러오기
        LoadData("all");
    }

    void Start()
    {
        Init();
    }
}
