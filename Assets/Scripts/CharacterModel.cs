using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterModel : MonoBehaviour
{
    [SerializeField] int fullness;
    public int Fullness { get { return fullness; } set { fullness = value; OnChanged?.Invoke(fullness); } }
    public UnityAction<int> OnChanged;

    [SerializeField] int maxFullness;
    public int MaxFullness { get { return maxFullness; } set { maxFullness = value; } }

    [SerializeField] int interactCount;
    public int InteractCount { get { return interactCount; } set { interactCount = value; } }

    [SerializeField] int stress;
    public int Stress { get { return stress; } set { stress = value; } }

    [SerializeField] int hp;
    public int Hp { get { return hp; } set { hp = value; } }
}
