//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HyllaScript : MonoBehaviour
//{

//    public float moveSpeed = 5;
//    [SerializeField] private float deadZone = -25;


//    void Update()
//    {
//        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

//        if (transform.position.x < deadZone)
//        {
//            Debug.Log("Hylla borta!");
//            Destroy(gameObject);
//        }
//    }    
//}
using System.Collections;
using UnityEngine;

public class HyllaScript : MonoBehaviour
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