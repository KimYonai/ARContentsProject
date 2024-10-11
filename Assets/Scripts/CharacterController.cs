using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public enum State { Idle, Jump }
    private State curState;

    [SerializeField] CharacterModel model;
    [SerializeField] Animator animator;

    private void Start()
    {
        curState = State.Idle;
        animator.SetBool("isTouch", false);
    }

    private void Update()
    {
        model.Fullness -= Time.deltaTime;

        TouchCharacter();
    }

    public void TouchCharacter()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                //Vector2 touchDelta = touch.deltaPosition;
                //Vector2 screenPos = touch.position;

                RaycastHit hit;
                var pos = Camera.main.ScreenPointToRay(touch.position);
                var ray = Physics.Raycast(pos, out hit, LayerMask.GetMask("Slime"));

                animator.SetBool("isTouch", true);
                curState = State.Jump;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                animator.SetBool("isTouch", false);
                curState = State.Idle;
            }
        }
    }
}
