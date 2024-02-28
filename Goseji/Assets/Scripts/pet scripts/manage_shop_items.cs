using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manage_shop_items : MonoBehaviour
{
    public furnitureSO furnitureSO;
    public int itemPrice;
    public GameObject sprite_obj;
    private SpriteRenderer spriteRenderer_obj;
    public Button purchase_btn;
    public Button apply_btn;

    void Start()
    {
        itemPrice = furnitureSO.fur_price;
        spriteRenderer_obj = sprite_obj.GetComponent<SpriteRenderer>();
        spriteRenderer_obj.sprite = furnitureSO.fur_sprite;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void is_purchased()
    {

    }
}
