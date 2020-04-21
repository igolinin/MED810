using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TextHandler : MonoBehaviour
{

    string pathJson;
    string jsonString;
    public TextContent textContent;

    // Start is called before the first frame update
    void Start()
    {
        pathJson = Application.streamingAssetsPath + "/json/InfoText.json";
        jsonString = File.ReadAllText(pathJson);

        textContent = JsonUtility.FromJson<TextContent>(jsonString);
        string testtext = textContent.HeaderBrorfelde;
        Debug.Log(testtext);
    }

    // Update is called once per frame
    public class TextContent{

        public string HeaderBrorfelde;
    }
}
