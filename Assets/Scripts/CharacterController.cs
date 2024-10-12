using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] CharacterModel model;
    [SerializeField] Animator animator;

    private float timer;
    private float delayTime;

    private void Start()
    {
        timer = 0;
        delayTime = 1.5f;
        animator.SetBool("isTouch", false);
        animator.SetBool("isEat", false);
    }

    private void Update()
    {
        model.Fullness -= Time.deltaTime;

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
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                var pos = Camera.main.ScreenPointToRay(touch.position);
                var ray = Physics.Raycast(pos, out hit, LayerMask.GetMask("Slime"));

                animator.SetBool("isTouch", true);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                animator.SetBool("isTouch", false);
            }
        }
    }

    public void OnTouchEatButton()
    {
        timer += Time.deltaTime;
        animator.SetBool("isEat", true);
        model.Fullness += 10;

        if (timer >= delayTime)
        {
            animator.SetBool("isEat", false);
        }
    }
}
