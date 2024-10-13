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
    [SerializeField] Collider characterCollider;

    [Header("UI")]
    [SerializeField] Slider fullnessSlider;
    [SerializeField] TextMeshProUGUI fullnessText;

    private void Start()
    {
        fullnessSlider.maxValue = model.MaxFullness;
        UpdateFullness(model.Fullness);
        characterCollider = GetComponent<Collider>();
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

            RaycastHit hit;
            var pos = Camera.main.ScreenPointToRay(touch.position);
            var ray = Physics.Raycast(pos, out hit, LayerMask.GetMask("Slime"));

            if (touch.phase == TouchPhase.Began && hit.collider == characterCollider)
            {
                animator.Play("Attack");
                model.Fullness -= 5;
            }
        }
    }

    public void OnTouchEatButton()
    {
        animator.Play("Jump");
        model.Fullness += 10;
    }

    private void UpdateFullness(int fullness)
    {
        fullnessSlider.value = fullness;
        fullnessText.text = $"{fullness}";
    }
}
