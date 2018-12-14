using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Cell : MonoBehaviour {

    //public string elementName; // Element Name
    //public int elementCount = 1; // Element Count
    //public Color elementColor; // Element Color
    public Transform elementTransform; //Transform Element
	private GameObject elementPrefab; 
    public item item = new item();

	//Method to update UI of this cell
	public void UpdateCellInterface () {
		if (elementPrefab == null) {
			elementPrefab = (FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory).elementPrefab;
		}
		if (item.elementCount == 0) {
			if (elementTransform != null) {
				Destroy (elementTransform.gameObject);
			}
			return;
		}
		else {
			if (elementTransform == null) {
				//spawn a new element prefab
				Transform newElement = Instantiate (elementPrefab).transform;
				newElement.parent = transform;
				newElement.localPosition = new Vector3 ();
				newElement.localScale = new Vector3 (1f,1f,1f);
				elementTransform = newElement;
			}
			//init UI elements
			Image bgImage = SimpleMethods.getChildByTag (elementTransform, "backgroundImage").GetComponent<Image> ();
			Text elementText = SimpleMethods.getChildByTag (elementTransform, "elementText").GetComponent<Text> ();
			Text amountText = SimpleMethods.getChildByTag (elementTransform, "amountText").GetComponent<Text> ();
			//change UI options
			bgImage.color = item.elementColor;
			elementText.text = item.elementName;
			amountText.text = item.elementCount.ToString ();
		}
	}

	//Change element options
	public void ChangeElement (string name, int count, Color color) {
		item.elementName = name;
		item.elementCount = count;
        item.elementColor = color;
		UpdateCellInterface ();
	}

	//Clear element
	public void ClearElement () {
		item.elementCount = 0;
		UpdateCellInterface ();
	}

}
