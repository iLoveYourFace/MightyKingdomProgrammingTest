using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Creates and manages the shop
public class Shop : MonoBehaviour
{
 //Items available for purchase
 [SerializeField] private ShopItem[] _shopItems;

 //Showing the catalog of items
 [SerializeField] private Transform shopContainer;
 [SerializeField] private GameObject shopItemPrefab;
 
 [SerializeField] private GameObject ownedItemPrefab;
 [SerializeField] private Transform itemsOwnedContainer;
 
 //Purchasing
 [SerializeField] private GameObject comfirmPurchasePrompt;
 [SerializeField] private GameObject comfirmPurchaseButton;
 [SerializeField] private GameObject insufficentFundsPrompt;
 [SerializeField] private Text comfirmPurchaseText;

 private GamplayHUD _gamplayHud;
 
 private void Start()
 {
  PopulateShop();
 }

//Generate the store catalog. Setting the price and sprite for each item
 void PopulateShop()
 {
  Debug.Log("PopulatingStore");
  for (int i = 0; i < _shopItems.Length; i++)
  {
     ShopItem shopItem = _shopItems[i];
     GameObject item = Instantiate(shopItemPrefab, shopContainer);

     item.transform.GetChild(1).GetComponent<Image>().sprite = shopItem.itemSprite;
     item.transform.GetChild(2).GetComponent<Text>().text = shopItem.itemPrice.ToString();
     
      if (shopItem.isOwned)
      {
       item.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
       item.transform.GetChild(1).GetComponent<Image>().color = Color.gray;
       GameObject ownedItem = Instantiate(ownedItemPrefab, itemsOwnedContainer);
       ownedItem.transform.GetChild(0).GetComponent<Image>().sprite = shopItem.itemSprite;
       item.transform.GetChild(2).GetComponent<Text>().text = "Owned";
      }
      else
      {
       item.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(shopItem, item));
      }
  }
 }

 //When you click on a shop item
 void OnButtonClick(ShopItem shopItem, GameObject item)
 {
  if (PlayerPrefs.HasKey("coinsPickedUp"))
  {
   if (PlayerPrefs.GetInt("coinsPickedUp") >= shopItem.itemPrice)
   {
    Debug.Log("You can afford " + shopItem.name + " at " + shopItem.itemPrice + " coins");
    comfirmPurchaseButton.GetComponent<Button>().onClick.RemoveAllListeners();
    comfirmPurchaseButton.GetComponent<Button>().onClick.AddListener(() => OnBuyButtonClick(shopItem, item));
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
   insufficentFundsPrompt.SetActive(true);
  }
 }

 //When the confirm purchase button is clicked
 void OnBuyButtonClick(ShopItem shopItem, GameObject item)
 {
  shopItem.isOwned = true;
  
  //Show purchased item
  GameObject ownedItem = Instantiate(ownedItemPrefab, itemsOwnedContainer);
  ownedItem.transform.GetChild(0).GetComponent<Image>().sprite = shopItem.itemSprite;
  
  //The button can no longer be interacted with, making UI reflect this
  item.GetComponent<Button>().interactable = false;
  item.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
  item.transform.GetChild(1).GetComponent<Image>().color = Color.gray;
  item.transform.GetChild(2).GetComponent<Text>().text = "Owned";

  //Subtract coins and update coin text
  PlayerPrefs.SetInt("coinsPickedUp", PlayerPrefs.GetInt("coinsPickedUp") - shopItem.itemPrice);
  _gamplayHud = FindObjectOfType<GamplayHUD>();
  _gamplayHud.UpdateCoinText(PlayerPrefs.GetInt("coinsPickedUp"));
  
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
