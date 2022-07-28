using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FindObjectWithConcretScript : MonoBehaviour
{
    public List<Transform> results = new List<Transform>();
    public MonoScript scriptObj = null;
    int loopCount = 0;

    [ContextMenu("найти")]
    public void FindObjectWithScript()   
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
