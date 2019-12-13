using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Creates and manages the shop
public class Shop : MonoBehaviour
{
 //Items available for purchase
 [SerializeField] private ShopItem[] _shopItems;

 //Showing the catalog of items
 [SerializeField] private Transform shopContainer;
 [SerializeField] private GameObject shopItemPrefab;
 
 //Purchasing
 [SerializeField] private GameObject comfirmPurchasePrompt;
 [SerializeField] private GameObject comfirmPurchaseButton;
 [SerializeField] private GameObject insufficentFundsPrompt;
 [SerializeField] private Text comfirmPurchaseText;
 
 private void Start()
 {
  PopulateShop();
 }

//Generate the store catalog. Setting the price and sprite for each item
 void PopulateShop()
 {
  for (int i = 0; i < _shopItems.Length; i++)
  {
     ShopItem shopItem = _shopItems[i];
     GameObject item = Instantiate(shopItemPrefab, shopContainer);

     item.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(shopItem));
     item.transform.GetChild(1).GetComponent<Image>().sprite = shopItem.itemSprite;
     item.transform.GetChild(2).GetComponent<Text>().text = shopItem.itemPrice.ToString();
  }
 }

 //when you click on a shop item
 void OnButtonClick(ShopItem shopItem)
 {
  if (PlayerPrefs.HasKey("coinsPickedUp"))
  {
   if (PlayerPrefs.GetInt("coinsPickedUp") >= shopItem.itemPrice)
   {
    Debug.Log("You can afford " + shopItem.name + " at " + shopItem.itemPrice + " coins");
    comfirmPurchaseButton.GetComponent<Button>().onClick.AddListener(() => OnBuyButtonClick(shopItem));
    comfirmPurchaseText.text = shopItem.name + " for " + shopItem.itemPrice + " coins?";
    comfirmPurchasePrompt.SetActive(true);
   }
   else
   {
    Debug.Log("You can NOT afford " + shopItem.name + " at " + shopItem.itemPrice + " coins");
    insufficentFundsPrompt.SetActive(true);
   }
  }
  else
  {
   Debug.Log("Error processing purchase of " + shopItem.name);
  }
 }

 void OnBuyButtonClick(ShopItem shopItem)
 {
  Debug.Log("Purchased " + shopItem.name);
 }

 public void SetGameObjectToInactive(GameObject gameObjectToSetInactive)
 {
  gameObjectToSetInactive.SetActive(false);
 }
 
 public void SetGameObjectToActive(GameObject gameObjectToSetInactive)
 {
  gameObjectToSetInactive.SetActive(true);
 }
}
