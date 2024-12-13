using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform agus;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - agus.position;

    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 targetPos = agus.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;


    }
}
