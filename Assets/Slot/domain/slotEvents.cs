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
    this.setData (slotModel.itemName, slotModel.quantity, slotModel.image);
  }

  private void setData(string name, int quantity, Sprite sprite) {
    this.name.text=name;
    this.quantity.text=quantity.ToString();
    this.sprite=sprite;
  }

  // Start is called before the first frame update
  void addItem()
    {
        
    }
}
