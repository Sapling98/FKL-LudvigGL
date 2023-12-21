using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // The target to follow (e.g., the player)

    public Vector3 targetRot = new Vector3(-11f, 0f, 0f);

    public float offSetx;
    public float offSety;
    public float offSetz;


    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + offSetx, player.position.y + offSety, offSetz);
            SetCameraRotation();
        }
    }

    void SetCameraRotation()
    {
        transform.eulerAngles = targetRot;
    }
}

