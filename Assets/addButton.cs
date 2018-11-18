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

    // Use this for initialization
    public void addItem () {

        if(inventory == null) {
            inventory = FindObjectOfType(typeof(ElementalInventory)) as ElementalInventory;
        }
        inventory.addItem(itemField.text, int.Parse(amount.text), new Color(Random.value / 2f, Random.value / 2f, Random.value / 2f, 1f));
        menuPanel.SetActive(false);
	}

    public void openMenu() {
        this.clean();
        menuPanel.SetActive(true);
    }

    private void clean() {
        itemField.text = "";
        amount.text = "1";
        slider.value = 1;
    }
}
