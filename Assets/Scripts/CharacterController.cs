using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [Header("Inspector")]
    [SerializeField] CharacterModel model;
    [SerializeField] CharacterView view;
    [SerializeField] Animator animator;
    [SerializeField] Collider characterCollider;
    [SerializeField] bool isTouch;
    [SerializeField] bool isClick;

    public enum State { Idle, Touch, Eat }
    [Header("State")]
    [SerializeField] State curState;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI fullnessText;

    private void Start()
    {
        isTouch = false;
        isClick = false;
        UpdateFullness(model.Fullness);
        characterCollider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        model.OnChanged += UpdateFullness;
    }
    
    private void OnDisable()
    {
        model.OnChanged -= UpdateFullness;
    }

    private void Update()
    {
        switch (curState)
        {
            case State.Idle:
                Idle();
                break;

            case State.Touch:
                Touch();
                break;

            case State.Eat: 
                Eat();
                break;
        }

        TouchCharacter();
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void TouchCharacter()
    {
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            Touch touch = Input.GetTouch(0);

            RaycastHit hit;
            var pos = Camera.main.ScreenPointToRay(touch.position);
            var ray = Physics.Raycast(pos, out hit, LayerMask.GetMask("Slime"));

            if (touch.phase == TouchPhase.Began && hit.collider == characterCollider)
            {
                isTouch = true;
                animator.Play("Attack");
                model.Fullness -= 5;
            }
            else
            {
                isTouch = false;
            }
        }
    }

    public void OnTouchEatButton()
    {
        if (Input.touchCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                isClick = false;
                return;
            }

            isClick = true;
            model.Fullness += 10;
        }
    }

    public void UpdateFullness(int fullness)
    {
        if (fullness > model.MaxFullness)
        {
            fullness = model.MaxFullness;
        }

        fullnessText.text = $"{fullness}";
    }

    private void Idle()
    {
        animator.Play("Idle");

        if (isTouch == true)
        {
            curState = State.Touch;
        }
        else if (isClick == true)
        {
            curState = State.Eat;
        }
    }

    private void Touch()
    {
        if (isTouch == false && isClick == false)
        {
            curState = State.Idle;
        }
        else if (isClick == true)
        {
            curState = State.Eat;
        }
    }

    private void Eat()
    {
        animator.Play("Jump");

        if (isTouch == false && isClick == false)
        {
            curState = State.Idle;
        }
        else if (isTouch == true)
        {
            curState= State.Touch;
        }
    }
}
