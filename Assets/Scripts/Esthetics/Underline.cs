using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Underline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string btnText;
    private TextMeshProUGUI textBtn;
    private void Awake()
    {
        textBtn = GetComponent<TextMeshProUGUI>();
    }
    public void UnderlineText()
    {
        textBtn.text = "<u>" + btnText + "</u>";
    }
    public void ClearText()
    {
        textBtn.text = btnText;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        UnderlineText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ClearText();
    }
}

