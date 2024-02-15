using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class furniture : MonoBehaviour
{
    [SerializeField]
    public furnitureSO furnitureSO;
    // public furnitureSO furnitureSO { set { FurnitureSO = value; } } 

    public void WatchfurnitureInfo()
    {
        Debug.Log("가구이름 :: " + furnitureSO.fur_name);
        Debug.Log("가구이름 :: " + furnitureSO.fur_price);
        Debug.Log("가구이름 :: " + furnitureSO.fur_type);
        Debug.Log("가구이름 :: " + furnitureSO.fur_relationship);
        Debug.Log("가구이름 :: " + furnitureSO.fur_serialnumber);
    }

    public void PrintfurnitureStatus()
    {
        print(furnitureSO.fur_name);
        print(furnitureSO.fur_price);
        print(furnitureSO.fur_type);
        print(furnitureSO.fur_relationship);
        print(furnitureSO.fur_serialnumber);
    }
}
