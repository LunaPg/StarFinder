using System.Collections;
using System.Collections.Generic;
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
        private class Wrapper<T>
    {
        public T [] Items;
    }
    public itemData [] cellsData;


    public string getFilePath()
    {
        return Application.persistentDataPath+"/inventory.json";
    }
    public void save(Cell[] cells)   {
        this.cellsData =new itemData [ cells.Length ];
        for ( int i = 0 ; i<cells.Length ; i++ )  {
            itemData itemData = new itemData ( );
            itemData.color=cells [ i ].color;
            itemData.gameObject=cells [ i ].gameObject;
            itemData.text=cells [ i ].name;
           // itemData.transform=cells [ i ].transform;
            this.cellsData [ i ]=itemData;
        }
        Wrapper<cellData.itemData> wrapper = new Wrapper<cellData.itemData> ( );
        wrapper.Items=cellsData;
        string inventory = JsonUtility.ToJson (wrapper, true);
 
        System.IO.File.WriteAllText (this.getFilePath ( ), inventory);
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void OnDisable()
    {
        
    }
}
