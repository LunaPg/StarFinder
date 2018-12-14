using UnityEngine;
using System.Collections;

public class ElementalInventory : MonoBehaviour {

	//Cell massive
	public Cell[] Cells;
	//Max element stack
	public int maxStack;
	public GameObject elementPrefab;
	private Transform choosenItem;

	public bool contains (string name, int count, Color color) {
		int inventoryCount = 0;
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].item.elementCount != 0 && Cells [i].item.elementName == name && Cells [i].item.elementColor == color) {
				inventoryCount += Cells [i].item.elementCount;
			}
		}
		if (count <= inventoryCount) {
			return true;
		} else {
			return false;
		}
	}

	//Set item from link
	public void setItemLink (string name, int count, Color color, Transform cell) {
		Cell thisCell = cell.GetComponent<Cell> ();
		thisCell.item.elementName = name;
		thisCell.item.elementCount = count;
		thisCell.item.elementColor = color;
	}

	//Moves item
	public void moveItem (int moveFrom, int moveTo) {
		setItem (Cells[moveFrom].item.elementName, Cells[moveFrom].item.elementCount, Cells[moveFrom].item.elementColor, moveTo);
		setItem ("", 0, new Color(), moveFrom);
	}

	//Moves item with link
	//First - element, second - cell
	public void moveItemLink (Transform moveFrom, Transform moveTo) {
		if (moveFrom != null && moveTo != null) {
			Cell moveFromCell = moveFrom.parent.GetComponent<Cell> ();
			moveTo.GetComponent<Cell> ().elementTransform = moveFromCell.elementTransform;
			moveFromCell.elementTransform = null;
			setItemLink (moveFromCell.item.elementName, moveFromCell.item.elementCount, moveFromCell.item.elementColor, moveTo);
			moveFromCell.item.elementCount = 0;
			moveFrom.parent = moveTo;
			moveFrom.localPosition = new Vector3 ();
		}
	}

	public void moveItemLinkFirst (Transform t) {
		choosenItem = t;
	}

	public void moveItemLinkSecond (Transform t) {
		moveItemLink (choosenItem, t);
		choosenItem = null;
	}

    public Cell getCell(Transform t) {
        return t.parent.GetComponent<Cell>();
    }

    //Sets item
    public void setItem (string name, int count, Color color, int cellId) {
		Cells [cellId].ChangeElement (name, count, color);
		Cells [cellId].UpdateCellInterface ();
	}

	//Loads inventory from string
	public void loadFromString (string s_Inventory) {
		string[] splitedInventory = s_Inventory.Split ("\n"[0]);
		for (int i = 0; i < Cells.Length; i++) {
			string[] splitedLine = splitedInventory [i].Split(" "[0]);
			setItem (splitedLine [0], int.Parse(splitedLine [1]), SimpleMethods.stringToColor(splitedLine [2]), i);
		}
	}

    public void loadFromSave() {
        for (int i = 0;  i < this.Cells.Length; i++) {
            setItem(this.Cells[0].item.elementName, this.Cells[0].item.elementCount, this.Cells[0].item.elementColor, i);
        }
    }

	//Returns inventory as string
	public string convertToString () {
		string s_Inventory = "";
		for (int i = 0; i < Cells.Length; i++) {
			s_Inventory += Cells[i].item.elementName+" ";
			s_Inventory += Cells [i].item.elementCount + " ";
			s_Inventory += SimpleMethods.colorToString (Cells[i].item.elementColor);
			if (i != Cells.Length) {
				s_Inventory += "\n";
			}
		}
		return s_Inventory;
	}

	//Clear inventory
	public void clear () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].item.elementCount != 0) {
				Cells [i].item.elementCount = 0;
				Cells [i].UpdateCellInterface ();
			}
		}
	}

	//Add element to inventory
	public void addItem (string name, int count, Color color) {
		int cellId = getEquals (name, color);
		if (cellId != -1) {
			Cells [cellId].item.elementCount = count;
		} else {
			cellId = getFirst ();
			if (cellId == -1) {
				return;
			}
			Cells [cellId].item.elementCount += count;
		}
		//Set up element count
		if (Cells [cellId].item.elementCount > maxStack) {
			int remain = Cells [cellId].item.elementCount - maxStack;
			Cells [cellId].item.elementCount = maxStack;
			addItem (name, remain, color);
		} else {
			Cells [cellId].item.elementCount = count;
		}
		Cells [cellId].item.elementName = name;
		Cells [cellId].item.elementColor = color;
		Cells [cellId].UpdateCellInterface ();
	}

	//Returns id of first clear cell
	public int getFirst () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].item.elementCount == 0) {
				return i;
			}
		}
		return -1;
	}

	//Returns id of first same element cell
	public int getEquals (string name, Color color) {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].item.elementCount != 0 && Cells [i].item.elementCount <= maxStack && Cells [i].item.elementName == name && Cells [i].item.elementColor == color) {
				return i;
			}
		}
		return -1;
	}
}
