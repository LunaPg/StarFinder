using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class slotModel :  ScriptableObject{
  public string itemName = "empty";
  public int quantity = 0;
  public Sprite image;

  protected string ItemName { get => itemName; set => itemName=value; }
  protected int Quantity { get => quantity; set => quantity=value; }
  protected Sprite Image { get => image; set => image=value; }

}


