using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] CharacterModel model;

    private StringBuilder fullnessSB = new StringBuilder();

    [SerializeField] TextMeshProUGUI fullnessText;

    private void Start()
    {
        UpdateFullness(model.Fullness);
    }
    
    private void OnEnable()
    {
        model.OnChanged += UpdateFullness;
    }
    
    private void OnDisable()
    {
        model.OnChanged -= UpdateFullness;
    }
    
    private void UpdateFullness(int fullness)
    {
        fullnessSB.Clear();
        fullnessSB.Append(fullness);
        fullnessText.SetText(fullnessSB);
    }
}
