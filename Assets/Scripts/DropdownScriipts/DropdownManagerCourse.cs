using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownManagerCourse : MonoBehaviour
{
    public Dropdown dropdown;
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

        //fill dropdown with list 
        if (gameObject.tag == "course")
        {
          
            foreach (var item in UnityDatabase.course)
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
        UnityDatabase.dropdown1 = dropdown.options[index].text;
    }
}
