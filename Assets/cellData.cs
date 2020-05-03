using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class cellData : ScriptableObject
{
    [System.Serializable]
    public class itemData
    {
        public Color color;
        public string text;
        public Transform transform;
        public GameObject gameObject;
    }
    // Wrapper to create key with array of objects
    [System.Serializable]
    private class Wrapper<T> {
        public T [] Items;
    }
    public itemData [] cellsData;
    private Cell [] cells;

    public string getFilePath() {
        Debug.Log (Application.persistentDataPath+"/inventory.json");
        return Application.persistentDataPath+"/inventory.json";
    }

    private itemData createItemData(Cell cell)  {
        itemData itemData = new itemData();
        itemData.color=cell.color;
        itemData.gameObject=cell.gameObject;
        itemData.text=cell.name;
        itemData.transform=cell.transform;
        return itemData;
    }

    private Cell createcell(itemData itemData)
    {
        Cell cell = new Cell ( );
        cell.color=itemData.color;
        //cell.gameObject=itemData.gameObject;
        // cell=itemData.text;
       // cell.transform=itemData.transform;
        return cell;
    }

    public void save(Cell[] cells) {
        this.cellsData =new itemData [ cells.Length ];
        for ( int i = 0 ; i<cells.Length ; i++ )  {
            itemData itemData = this.createItemData(cells[i]);
            this.cellsData [ i ]=itemData;
        }
        Wrapper<cellData.itemData> wrapper = new Wrapper<cellData.itemData> ( );
        wrapper.Items=cellsData;
        string inventory = JsonUtility.ToJson (wrapper, true);
        File.WriteAllText(this.getFilePath(), inventory);
    }

    public Cell [] load()
    {
        //string jsonData = "";
        //jsonData=System.Text.Encoding.UTF8.GetString (myWWW.bytes, 3, myWWW.bytes.Length-3);  // Skip thr first 3 bytes (i.e. the UTF8 BOM)
        //JSONObject json = new JSONObject (jsonData);
        string inventory = File.ReadAllText (this.getFilePath ( ));
        Wrapper<cellData.itemData> wrapper = JsonUtility.FromJson<Wrapper<cellData.itemData>> (inventory);
        //return wrapper.Items;
        for ( int i = 0 ; i<wrapper.Items.Length ; i++ )
        {
            Cell cell = createcell (wrapper.Items [ i ]);
            this.cells [ i ]=cell;
        }
        return this.cells;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void OnDisable() {
        
    }
}
