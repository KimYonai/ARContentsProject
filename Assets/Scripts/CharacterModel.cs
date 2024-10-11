using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    [SerializeField] float fullness;
    public float Fullness { get { return fullness; } set { fullness = value; } }

    [SerializeField] int interactCount;
    public int InteractCount { get { return interactCount; } set { interactCount = value; } }

    [SerializeField] int stress;
    public int Stress { get { return stress; } set { stress = value; } }

    [SerializeField] int hp;
    public int Hp { get { return hp; } set { hp = value; } }
}
