using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class selectedoption : MonoBehaviour
{
    ToggleGroup ToggleGroupInstance;

    public Toggle currentSelection
    {
       get { return ToggleGroupInstance.ActiveToggles().FirstOrDefault(); }   
    }

    public string submit()
    {
         ToggleGroupInstance = GetComponent<ToggleGroup>();
         Debug.Log("Gender is : " + currentSelection.name);
        return currentSelection.name.ToString();
    }
    public void ClearToggles()
    {
        ToggleGroupInstance.SetAllTogglesOff();
    }
}
