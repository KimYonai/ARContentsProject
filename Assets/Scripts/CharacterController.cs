using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public enum CharacterState { Idle, Interact, Annoying, Angry, Eat, Die }
    [SerializeField] CharacterState curState;

    private CreateCharacter character;

    private void Start()
    {
        curState = CharacterState.Idle;
    }

    private void Update()
    {
        switch (curState)
        {
            case CharacterState.Idle:
                Idle();
                break;

            case CharacterState.Interact:
                Interact();
                break;

            case CharacterState.Annoying:
                Annoying();
                break;

            case CharacterState.Angry:
                Angry();
                break;

            case CharacterState.Eat:
                Eat();
                break;

            case CharacterState.Die:
                Die();
                break;
        }
    }

    private void Idle()
    {

    }

    private void Interact()
    {

    }

    private void Annoying()
    {

    }

    private void Angry()
    {

    }

    private void Eat()
    {

    }

    private void Die()
    {

    }
}
