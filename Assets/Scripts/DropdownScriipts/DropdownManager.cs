using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownManager : MonoBehaviour
{
    public Dropdown dropdown;
    private void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();   


        //fill dropdown with list 
        if (gameObject.tag == "depart")
        {

            foreach (var item in UnityDatabase.departs)
            {

                dropdown.options.Add(new Dropdown.OptionData() { text = item });
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
        UnityDatabase.dropdown = dropdown.options[index].text;

    }
}
