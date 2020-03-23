using UnityEngine;
using System.Collections;

public class RandomItem : MonoBehaviour {

	private ElementalInventory inventory;

	void Update () {
		if (inventory == null) {
			inventory = FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory;
		}
		if (Input.GetKeyDown (KeyCode.G)) {
            string randomElement = SimpleMethods.randomElement ( );
            int randomSlot = Random.Range (1, inventory.maxStack);
            Color randomColor = new Color (Random.value/2f, Random.value/2f, Random.value/2f, 1f);
            inventory.addItem (randomElement, randomSlot, randomColor) ;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			inventory.clear ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			PlayerPrefs.SetString ("EInventory", inventory.convertToString());
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			inventory.loadFromString (PlayerPrefs.GetString("EInventory"));
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			inventory.gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			inventory.gameObject.SetActive (true);
		}
	}

}
