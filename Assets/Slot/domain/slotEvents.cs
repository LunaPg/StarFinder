using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slotEvents : MonoBehaviour
{
  public slotModel slotModel;
  public Text quantity;
  public Text name;
  public Sprite sprite;
  

  public void Start(){
    this.sprite=GetComponent<Sprite> ( );
    this.slotModel=ScriptableObject.CreateInstance<slotModel>();
    this.addItem (slotModel.itemName, slotModel.quantity, slotModel.image);
  }

  private void addItem(string name, int quantity, Sprite sprite) {
    this.name.text=name;
    this.quantity.text=quantity.ToString();
    this.sprite=sprite;
  }

  private void modifyItem (string name, int quantity, Sprite sprite){
    this.name.text=name;
    this.quantity.text=quantity.ToString ( );
    this.sprite=sprite;
  }

  private void deleteItem(string name, int quantity, Sprite sprite){
    this.slotModel.name="empty";
    this.slotModel.quantity=0;
    this.slotModel.image=null;
    this.addItem (slotModel.itemName, slotModel.quantity, slotModel.image);
  }
}
