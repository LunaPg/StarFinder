using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MovingEvent : MonoBehaviour {

	private ElementalInventory inventory;
    private addButton panel;

	void Start () {
		if (transform.tag == "SaveCell") {
            GetComponent<Button>().onClick.AddListener(delegate { openMenu(); });
            //GetComponent<Button> ().onClick.AddListener (delegate{moveHere();});
        } else {
			// GetComponent<Button> ().onClick.AddListener (delegate{moveItem();});
            GetComponent<Button>().onClick.AddListener(delegate { modifyItem(); });
        }
	}

    private addButton getPanel() {
        addButton panel = FindObjectOfType (typeof (addButton)) as addButton;
        if ( panel==null ) {
            throw new Exception ("Pannel is not found");
        }
        return panel;
}

    public void openMenu() {
        if (this.panel == null) {
            this.panel = FindObjectOfType(typeof(addButton)) as addButton;
        }

       this. panel.clean();
        this.panel.openMenu();
    }

    public void modifyItem() {
        if (this.panel == null)
        {
            this.panel=this.getPanel ( );
        }
        print (transform);
        Cell cell = inventory.getCell(transform);
        if ( cell==null ) {
            throw new Exception ("Cannot modify item, SaveCell has not been found !");
        }
       this. panel.currentCell = cell;
        this.panel.setValues(cell.item.elementName, cell.item.elementCount);
       this. panel.openMenu();
    }

	public void moveItem () {
		if (inventory == null) {
			inventory = FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory;
		}
		inventory.moveItemLinkFirst (transform);
	}

	public void moveHere () {
		if (inventory == null) {
			inventory = FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory;
		}
		inventory.moveItemLinkSecond (transform);
	}

}
