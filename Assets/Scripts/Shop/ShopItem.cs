using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
 public string itemName;
 public int itemPrice;
 public Sprite itemSprite;
 public bool isOwned;
}
