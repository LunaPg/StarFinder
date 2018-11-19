using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovingEvent : MonoBehaviour {

	private ElementalInventory inventory;
    private addButton panel;

	void Start () {
		if (transform.tag == "Cell") {
            GetComponent<Button>().onClick.AddListener(delegate { openMenu(); });
            //GetComponent<Button> ().onClick.AddListener (delegate{moveHere();});
        } else {
			// GetComponent<Button> ().onClick.AddListener (delegate{moveItem();});
            GetComponent<Button>().onClick.AddListener(delegate { modifyItem(); });
        }
	}

    public void openMenu() {
        if (panel == null) {
            panel = FindObjectOfType(typeof(addButton)) as addButton;
        }
        panel.clean();
        panel.openMenu();
    }

    public void modifyItem() {
        if (panel == null)
        {
            panel = FindObjectOfType(typeof(addButton)) as addButton;
        }
        Cell cell = inventory.getCell(transform);
        panel.currentCell = cell;
        panel.setValues(cell.elementName, cell.elementCount);
        panel.openMenu();
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
