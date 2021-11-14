using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Underline : MonoBehaviour
{
    [SerializeField] private string btnText;
    private TextMeshProUGUI textBtn;
    private void Awake()
    {
        textBtn = GetComponent<TextMeshProUGUI>();
    }
    public void UnderlineText()
    {
        textBtn.text = "<u>"+btnText+"</u>";
    }
    public void ClearText()
    {
        textBtn.text = btnText;
    }
}
