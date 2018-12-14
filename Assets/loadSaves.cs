using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class loadSaves : MonoBehaviour
{
    public ElementalInventory inventory;

    public savingHandler saveSetup() {
        inventory = FindObjectOfType(typeof(ElementalInventory)) as ElementalInventory;
        savingHandler save = new savingHandler();
        // save.cells = inventory.Cells;
        // Saving items
        // getting item to cell objet.

        return save;
    }

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

            inventory.Cells = save.cells;
            inventory.loadFromSave();
            Debug.Log("Game Loaded");
        } else {
            Debug.Log("T'as pas de game Jean Michel !");
        }


    }
}
