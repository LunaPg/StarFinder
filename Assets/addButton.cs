using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addButton : MonoBehaviour {

    public Text item;
    public Text amount;
    private ElementalInventory inventory;

    // Use this for initialization
    public void addItem () {
        if(inventory == null) {
            inventory = FindObjectOfType(typeof(ElementalInventory)) as ElementalInventory;
        }
        inventory.addItem(item.text, int.Parse(amount.text), new Color(Random.value / 2f, Random.value / 2f, Random.value / 2f, 1f));
	}
}
