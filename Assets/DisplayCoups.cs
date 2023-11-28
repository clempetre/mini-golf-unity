using UnityEngine;
using UnityEngine.UI;

public class DisplayCoups : MonoBehaviour
{
    public Controlpoint controlPoint; // Référence au script Controlpoint

    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        UpdateCoupsDisplay();
    }

    void Update()
    {
        UpdateCoupsDisplay();
    }

    void UpdateCoupsDisplay()
    {
        if (controlPoint != null)
        {
            textComponent.text = "Coup n°" + controlPoint.Coups.ToString();
        }
    }
}
