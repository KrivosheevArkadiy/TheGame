using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour
{
    public GameObject _UIManager;

    [System.Serializable]
    public class Pick
    {
        public string _pick;
        public float x;
         

    }

    // Use this for initialization
    void Save()
    {
        Pick option = new Pick();
        option._pick = _UIManager.GetComponent<UIManagerScript>()._pick; // сохраняет выбор перса

        if (!Directory.Exists(Application.dataPath + "/saves")) // проверяем наличие папки сохранения
            Directory.CreateDirectory(Application.dataPath + "/saves"); // если нет то создаем
        FileStream fs = new FileStream(Application.dataPath + "/saves/save.sav", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, option);
        fs.Close();
    }
    void Load()
    {
        if(File.Exists(Application.dataPath + "/saves/save.sav"))
        {
            FileStream fs = new FileStream(Application.dataPath + "/saves/save.sav", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                Pick pos = (Pick)formatter.Deserialize(fs);
                //     _UIManager.GetComponent<UIManagerScript>()._pick = ;
            }
            catch { }
        }

    }
    // Update is called once per frame
    
}
