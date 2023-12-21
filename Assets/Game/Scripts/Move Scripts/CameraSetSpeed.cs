using UnityEngine;

public class CameraSetSpeed : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 targetRot = new Vector3 (45f, 0f, 0f);
    public float offSetx;
    public float offSety;
    public float offSetz;


    private void Update()
    {
        SetCameraRotation();
        MoveRight();
    }

    private void Start()
    {
        transform.position = new Vector3(offSetx, offSety, offSetz);
        SetCameraRotation();
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
