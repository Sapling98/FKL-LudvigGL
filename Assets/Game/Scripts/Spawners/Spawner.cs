//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HyllaSpawner : MonoBehaviour
//{
//    public GameObject Hylla;
//    public float spawnRate = 2;
//    private float heightOffset = 7;
//    private float timer = 0;

//    // Start is called before the first frame update
//    void Start()
//    {
//        spawnHylla();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (timer < spawnRate)
//        {
//            timer = timer + Time.deltaTime;
//        }
//        else
//        {
//            spawnHylla();
//            timer = 0;
//        }
//    }

//    void spawnHylla()
//    {
//        float lowestPoint = transform.position.y - heightOffset;
//        float highestPoint = transform.position.y + heightOffset;
//        Instantiate(Hylla, new Vector3(transform.position.x, Random.Range(highestPoint, lowestPoint), 0), transform.rotation);
//    }
//}