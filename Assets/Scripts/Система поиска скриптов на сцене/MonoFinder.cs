using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class MonoFinder : EditorWindow
{
    MonoScript scriptObj = null;
    List<Transform> results = new List<Transform>();

    [MenuItem("Seek/Finder/MonoFinder")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(MonoFinder));
    }
    void OnGUI()
    {        
        GUILayout.Label ("Скрипт");
        scriptObj = (MonoScript)EditorGUILayout.ObjectField(scriptObj, typeof(MonoScript), true);
        
        if (GUILayout.Button("Поиск"))
        {
                results.Clear();
                Debug.Log ("Начать поиск.");
                FindScript();
        }
        if (results.Count > 0)
        {
            foreach (Transform t in results)
            {
                EditorGUILayout.ObjectField(t, typeof(Transform), false);
            }
        }
        else
        {
            GUILayout.Label ("Нет данных");
        }
    }
    
    void FindScript()
    {
        Object[] allObjects = Object.FindObjectsOfType(typeof(GameObject));

        if (scriptObj != null)
        {
            foreach (GameObject item in allObjects)
            {
                if (item.GetComponent(scriptObj.GetClass()) != null)
                {
                    results.Add(item.transform);
                }
            }
            
        }
    }

}