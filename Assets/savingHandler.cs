using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class savingHandler {

    public static savingHandler saveData;
    public SaveCell [] CellsSaved;
    public cellData cellData;

    public ElementalInventory inventory;

    public class SaveCell {
        public Transform elementTransform; //Transform Element
        public  GameObject elementPrefab;
        public item item = new item ( );
        public Color color;
    }

    public string getFilePath() {
        return Application.persistentDataPath+"/inventory.json";
    }

    public void saveInventory() {
        for ( int i = 0 ; i <  this.inventory.Cells.Length ; i++  )
        {
           // Cell  inventoryCell  =  c.GetComponent<Cell> ( );
            SaveCell saveCell = new SaveCell ( );
            saveCell.color=this.inventory.Cells[i].color;
            saveCell.elementTransform=this.inventory.Cells [ i ].elementTransform;
            saveCell.item=this.inventory.Cells [ i ].item;
            this.CellsSaved [ i ]=saveCell;
        }
        // this.Cells = this.inventory.Cells;
       string inventory =  JsonUtility.ToJson (this.CellsSaved, true);
        System.IO.File.WriteAllText (this.getFilePath(),inventory );
    }

    public void loadCells(SaveCell[] cells)
    {
        for ( int i = 0 ; i<this.CellsSaved.Length ; i++ )
        {
             this.inventory.setItem (this.CellsSaved [ 0 ].item.elementName, this.CellsSaved [ 0 ].item.elementCount, this.CellsSaved [ 0 ].item.elementColor, i);
        }
    }

    public void loadInventory() {
        this.CellsSaved=JsonUtility.FromJson<SaveCell []> ( this.getFilePath() );
        this.loadCells (CellsSaved);
    }


}
