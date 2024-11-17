using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleTextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData();
    }

    public void UpdateText()
    {
        UpdateWithIntData();
    }
    
    public void UpdateWithIntData()
    {
        if (dataObj != null)
        {
            textObj.text = "Score: " + dataObj.value.ToString();
        }
        else
        {
            Debug.LogWarning("DataObj is not assigned!");
        }
    }
}
