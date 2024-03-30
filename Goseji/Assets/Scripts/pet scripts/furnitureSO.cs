using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="furnitureSO", menuName ="ScriptableObject/furnitureSO")]
public class furnitureSO : ScriptableObject
{
    public string fur_name;
    public Sprite fur_sprite;
    public int fur_price;
    public int fur_relationship; // 호감치임, max =1000
    public enum fur_Type
    {
        CATTOWER,
        TOY,
        SCRATCHER
    }
    public fur_Type fur_type;
    public int fur_serialnumber;
}
