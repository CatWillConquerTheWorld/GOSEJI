using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnfurniture : MonoBehaviour
{
    [SerializeField]
    private List<furnitureSO> furnitureSOs = new List<furnitureSO>();
    [SerializeField]
    private GameObject furniturePrefab;

    private SpriteRenderer spriterenderer;



    void Start()
    {
        instant_fur();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }



    public void instant_fur()
    {
        foreach (var furnitureSO in furnitureSOs)
        {
            var createFurniture = Instantiate(furniturePrefab).GetComponent<furniture>();
            spriterenderer = createFurniture.GetComponent<SpriteRenderer>();
            createFurniture.gameObject.name = furnitureSO.name;
            spriterenderer.sprite = furnitureSO.fur_sprite;
            createFurniture.furnitureSO = furnitureSO;
            createFurniture.PrintfurnitureStatus();
        }
    }




    // Âü°í https://velog.io/@kimwonseop/%EC%8A%A4%ED%81%AC%EB%A6%BD%ED%84%B0%EB%B8%94-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8ScriptableObject
}
