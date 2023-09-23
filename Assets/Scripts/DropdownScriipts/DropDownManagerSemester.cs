using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManagerSemester : MonoBehaviour
{
     List<int> sem = new List<int>();
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        for(int i = 1; i <=8; i++)
        {
            sem.Add(i);
        }

        //fill dropdown with list 
        if (gameObject.tag == "sem")
        {

            foreach (int item in sem)
            {
                dropdown.options.Add(new Dropdown.OptionData() { text = item.ToString() });
            }

        }


        dropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate
        {
            dropdownItemSelected(dropdown);
        });
    }

    public void dropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        Debug.Log(dropdown.options[index].text);
        UnityDatabase.dropdown2 = dropdown.options[index].text;
    }
}
