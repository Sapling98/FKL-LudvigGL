using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMove : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 targetRot = new Vector3(0f, 0f, 0f);
    public float offSetx;
    public float offSety;
    public float offSetz;

    private void Start()
    {
        transform.position = new Vector3(offSetx, offSety, offSetz);
    }

    private void Update()
    {
        SetCameraRotation();
        MoveRight();
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    void SetCameraRotation()
    {
        transform.eulerAngles = targetRot;
    }
}