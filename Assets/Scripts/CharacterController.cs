using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [Header("Inspector")]
    [SerializeField] CharacterModel model;
    [SerializeField] Animator animator;

    [Header("UI")]
    [SerializeField] Slider fullnessSlider;
    [SerializeField] TextMeshProUGUI fullnessText;

    private float timer;
    private float delayTime;

    private void Start()
    {
        timer = 0;
        delayTime = 1.5f;
        fullnessSlider.maxValue = model.MaxFullness;
        UpdateFullness(model.Fullness);
        animator.SetBool("isTouch", false);
        animator.SetBool("isEat", false);
    }

    private void Update()
    {
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

                model.Fullness -= 5;
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

    private void UpdateFullness(int fullness)
    {
        fullnessSlider.value = fullness;
        fullnessText.text = $"{fullness}";
    }
}
