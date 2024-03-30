using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class testfurniture : MonoBehaviour
{
    [SerializeField]
    private List<furnitureSO> furnitureSOss = new List<furnitureSO>();
    [SerializeField]
    private GameObject furniture; // 가구 자기자신

    private SpriteRenderer spriterenderer;

    [SerializeField]
    public furnitureSO furnitureSO_mine;

    private string furName;
    private Sprite furSprite;
    private int furPrice;
    private int furRelationship;
    private enum furType
    {
        CATTOWER,
        TOY,
        SCRATCHER
    }
    private furType furType_;
    private int furSerialNumber;

    void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_furniture(string fur_name)
    {
        foreach (var furnitureSO in furnitureSOss)
        {
            if(fur_name == furnitureSO.fur_name)
            {
                furName = furnitureSO.fur_name;
                furSprite = furnitureSO.fur_sprite;
                furPrice = furnitureSO.fur_price;
                furRelationship = furnitureSO.fur_relationship;

                spriterenderer.sprite = furnitureSO.fur_sprite;
                Debug.Log(furName + furPrice + furRelationship);
            }
        }
    }
}
