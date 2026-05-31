using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoMetros;

    public void Distance(int value)
    {
        textoMetros.text = value + "M";
    }
}