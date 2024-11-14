using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SimpleImageBehaviour : MonoBehaviour
{
    private Image imageObj;
    public SimpleFloatData healthDataObj;
    public SimpleFloatData staminaDataObj;

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }

    public void UpdateWithFloatData(bool isHealth)
    {
        if (isHealth && healthDataObj != null)
        {
            imageObj.fillAmount = healthDataObj.value;
        }
        else if (!isHealth && staminaDataObj != null)
        {
            imageObj.fillAmount = staminaDataObj.value;
        }
    }
}
