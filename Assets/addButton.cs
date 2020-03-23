using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addButton : MonoBehaviour {

    public InputField itemField;
    public Text amount;
    public Slider slider;
    public GameObject menuPanel;
    private ElementalInventory inventory;
    public Cell currentCell = null;


    public void  upsert() {
        if (currentCell != null)
        {
            putItem();
        }
        else {
            addItem();
        }
    }
    // Use this for initialization
    public void addItem () {

        if(inventory == null) {
            inventory = FindObjectOfType(typeof(ElementalInventory)) as ElementalInventory;
        }
        Color color = new Color ( Random.value/2f, Random.value/2f, Random.value/2);
        inventory.addItem(itemField.text, int.Parse(amount.text), color);
        menuPanel.SetActive(false);
	}

    // Use this for initialization
    public void putItem()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType(typeof(ElementalInventory)) as ElementalInventory;
        }
        int index = inventory.getEquals(currentCell.item.elementName, currentCell.item.elementColor);
        inventory.setItem(itemField.text, int.Parse(amount.text), currentCell.item.elementColor, index);
        menuPanel.SetActive(false);
    }

    public void openMenu() {
        menuPanel.SetActive(true);
    }

    public void clean() {
        itemField.text = "";
        amount.text = "1";
        slider.value = 1;
    }

    public void setValues(string name, int quantity) {
        itemField.text = name;
        amount.text = quantity.ToString();
        slider.value = quantity;
    }

    public void minusAmount() {
        slider.value -= 1;
    }

    public void plusAmount() {
        slider.value += 1;
    }
}
