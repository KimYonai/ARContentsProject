using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CreateCharacter : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] bool isSpawned = false;

    public void SpawnCharacter()
    {
        if (isSpawned != false)
            return;

        Ray ray = new Ray();
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(ray, hits))
        {
            Instantiate(character, hits[0].pose.position, Quaternion.Euler(hits[0].pose.rotation.x, hits[0].pose.rotation.y - 180, hits[0].pose.rotation.z));
            isSpawned = true;
        }
    }
}
