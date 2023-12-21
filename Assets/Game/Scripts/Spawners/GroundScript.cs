using System.Collections;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float destroyDelay = 5f; // Adjust this value as needed

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Debug.Log("Hylla borta!");
        Destroy(gameObject);
    }
}