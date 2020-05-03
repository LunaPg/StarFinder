using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class loadSaves : MonoBehaviour
{
    public ElementalInventory inventory;
    public savingHandler savingHandler;
    public cellData cellData;
    public Cell [] cells ;

    public void save() {
        cellData=ScriptableObject.CreateInstance<cellData>();
        // this.savingHandler.saveInventory ( );
        this.cellData.save (inventory.Cells );
    }

    public void load() {
       cells =  this.cellData.load ( );
    }
    /**
    public void save() {
        savingHandler saveData = saveSetup();
        // Creattig buffer, and save in file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Game Saved");
    }

    public void load() {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            savingHandler save = (savingHandler)bf.Deserialize(file);
            file.Close();
            Debug.Log (save);

            // reconstruct celles
            //   inventory.Cells = save.cells;
            this.reconstruct (save.items);
            // inventory.contains ( );
            inventory.loadFromSave();
            Debug.Log("Game Loaded");
        } else {
            Debug.Log("T'as pas de game Jean Michel !");
        }
    }
    **/
    protected void reconstruct(item[] items) {
        if ( items.Length!=inventory.Cells.Length )
        {
            throw  new System.Exception( "Your Cells should be = to Items");
        }
        for ( int i = 0 ; i>items.Length ; i++ )
        {
            inventory.setItem (items [ i ].elementName, items [ i ].elementCount, items [ i ].elementColor, i);

             //    inventory.Cells [ i ].item=items [ 0 ];
        }
    }
}
