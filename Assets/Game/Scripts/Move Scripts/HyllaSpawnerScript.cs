using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyllaSpawnerScript : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        MoveRight();
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
