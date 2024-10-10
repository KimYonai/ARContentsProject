using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    [SerializeField] int fullness;
    public int Fullness { get { return fullness; } set { fullness = value; } }

    [SerializeField] int interActCount;
    public int InterActCount { get { return interActCount; } set { interActCount = value; } }

    [SerializeField] int stress;
    public int Stress { get { return stress; } set { stress = value; } }

    [SerializeField] int hp;
    public int Hp { get { return hp; } set { hp = value; } }
}
