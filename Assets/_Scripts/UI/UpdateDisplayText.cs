using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateDisplayText : MonoBehaviour
{
    private TextMeshProUGUI displayText;
    public void SetText(int ID, string title)
    {
        displayText = GetComponentInChildren<TextMeshProUGUI>();
        displayText.text = $"Floor {ID} \n {title}";
    }
}
