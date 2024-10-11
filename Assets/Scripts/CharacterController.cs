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

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.deltaPosition;
                Vector2 screenPos = touch.position;

                RaycastHit hit;
                var pos = Camera.main.ScreenPointToRay(screenPos);
                var ray = Physics.Raycast(pos, out hit, LayerMask.GetMask("Slime"));

                //if (ray)
                //{
                //    if (touchDelta.x > 0)
                //    {
                //        hit.transform.gameObject.GetComponent<Animator>().Play();
                //    }
                //    else
                //    {
                //        hit.transform.gameObject.GetComponent<Animator>().Play();
                //    }
                //}
                //else
                //{
                //    return;
                //}
            }
        }
    }
}
