using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SetPos3 : MonoBehaviour
{
    public string json_url;
    public JsonClass json_data;
    public GameObject cube;

    void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        Debug.Log("Загрузка...");
        var uwr = new UnityWebRequest(json_url);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result3.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Ошибка!");
        }
        else
        {
            Debug.Log("Файл сохранен по пути:" + resultFile);
            json_data = JsonUtility.FromJson<JsonClass>(File.ReadAllText(Application.persistentDataPath + "/result3.json"));
            move_obj();
            Debug.Log(json_data.X);
            Debug.Log(json_data.Y);
            Debug.Log(json_data.Z);
            //yield return break;
            //yield return StartCoroutine(getData());
        }
    }

    public void move_obj()
    {
        cube.transform.position = new Vector3(json_data.X, json_data.Y, json_data.Z);
    }

    [System.Serializable]
    public class JsonClass
    {
        public string Name;
        public int X;
        public int Y;
        public int Z;
    }
}