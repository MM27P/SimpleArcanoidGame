using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update
    string fileName = "Save.txt";

    public SaveFileObject Load()
    {
        string content = File.ReadAllText(fileName);
        SaveFileObject temp = new SaveFileObject();
        temp = JsonUtility.FromJson<SaveFileObject>(content);
        return temp;
    }

    public void Save(SaveFileObject temp)
    {
        string content = JsonUtility.ToJson(temp);
        File.WriteAllText(fileName, content);
    }
}
