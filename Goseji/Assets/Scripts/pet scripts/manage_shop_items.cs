using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manage_shop_items : MonoBehaviour
{
    public furnitureSO furnitureSO;
    public int itemPrice;
    public string itemName;

    public GameObject sprite_obj;
    private SpriteRenderer spriteRenderer_obj;
    private Image sprite_image;
    public Button purchase_btn;
    public Button apply_btn;
    public int mymoney;
    public TextMeshPro itemName_txt;

    void Start()
    {
        itemPrice = furnitureSO.fur_price;
        itemName = furnitureSO.fur_name;
        Image sprite_image = sprite_obj.GetComponent<Image>();
        sprite_image.sprite = furnitureSO.fur_sprite;
        // itemName_txt.text = itemName.ToString();
        purchase_btn.gameObject.SetActive(true);
        apply_btn.gameObject.SetActive(false);


        Debug.Log("이 아이템의 이름 : " + itemName + "이고, 가격은 " + itemPrice + "입니다. 내 재산 : " + mymoney);
    }

    private void Update()
    {
        mymoney = GameManager.Instance.money;
    }

    public void purchaseItem()
    {
        if(itemPrice <= mymoney)
        {
            mymoney = mymoney - itemPrice;
            PlayerPrefs.GetInt("money", mymoney);

            purchase_btn.gameObject.SetActive(false);
            apply_btn.gameObject.SetActive(true);
            Debug.Log("아이템 구매에 성공하셨습니다.~!" + mymoney);

        }else if(itemPrice > mymoney)
        {
            Debug.Log("아이템 구매에 실패하셨습니다.~! 현재 가격 및 재산"+ itemPrice + mymoney);
        }
    }

    void is_purchased()
    {

    }

    public void applyItem()
    {

        Debug.Log("아이템을 적용합니다.~"+ mymoney);
    }
}
