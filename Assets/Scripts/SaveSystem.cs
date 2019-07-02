using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public static class SaveSystem
{
    
    public static void SaveSens(Sensitivity sens)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/sens.fun";

        

        
        FileStream stream = new FileStream(path, FileMode.Create);

        SensData data = new SensData(sens);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SensData LoadSens()
    {
        string path = Application.persistentDataPath + "/sens.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            

            FileStream stream = new FileStream(path, FileMode.Open);

            SensData data = formatter.Deserialize(stream) as SensData;

            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

}
