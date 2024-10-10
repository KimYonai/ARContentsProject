using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public enum CharacterState { Idle, Interact, Annoying, Angry, Eat, Die }
    [SerializeField] CharacterState curState;

    private CreateCharacter character;
    private Vector2 touchPos;

    [Header("Model")]
    [SerializeField] CharacterModel model;

    private void Start()
    {
        curState = CharacterState.Idle;
    }

    private void Update()
    { 
        #region State Change
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
        #endregion 
    }

    public void TouchAction()
    {
        if (Input.touchCount > 0)
            return;

        Touch touch = Input.GetTouch(0);
        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

        if (hit.collider.tag == "Player" && model.Stress <= 10)
        {
            curState = CharacterState.Interact;
        }
        else if (hit.collider.tag == "Player" && model.Stress > 10 && model.Stress <= 20)
        {
            curState = CharacterState.Annoying;
        }
        else if (hit.collider.tag == "Player" && model.Stress > 20 && model.Stress <= 30)
        {
            curState = CharacterState.Angry;
        }
        else if (hit.collider.tag == "Player" && model.Stress > 30)
        {
            curState = CharacterState.Die;
        }
    }

    public void TouchEatButton()
    {
        curState = CharacterState.Eat;

        if (model.Fullness <= 80)
        {
            model.Stress -= 5;
            model.Fullness += 20;
        }
        else if (model.Fullness > 80 &&  model.Fullness < 100)
        {
            model.Stress -= 5;
            model.Fullness += 100 - model.Fullness;
        }
        else if (model.Fullness >= 100)
        {
            model.Stress += 10;
        }
    }

    private void Idle()
    {


        TouchAction();
    }

    private void Interact()
    {


        TouchAction();
    }

    private void Annoying()
    {


        TouchAction();
    }

    private void Angry()
    {


        TouchAction();
    }

    private void Eat()
    {


        TouchAction();
    }

    private void Die()
    {


        Destroy(gameObject);
        character.isSpawned = false;
    }
}
