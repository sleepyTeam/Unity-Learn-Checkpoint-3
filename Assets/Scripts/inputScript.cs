using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class inputScript : MonoBehaviour
{
    
    public void SaveName(string name)
    {
  
        Debug.Log(name);
        DataManager.instance.playerName = name;
    }

 
}
