using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class ObjectPool : MonoBehaviour
{

    //[Serializable]
    //public class Pool // birden fazla pool icinde uretilecek farkli tur obje varsa bunu kullanicam 
    //{
    //    public Queue<GameObject> poolObjects;
    //    public GameObject objectPrefab;
    //    public int poolSize;
    //}

    //[SerializeField] Pool[] pools = null;

    //private void Awake()
    //{
    //    for (int j = 0; j < pools.Length; j++)
    //    {
    //        pools[j].poolObjects = new Queue<GameObject>();

    //        for (int i = 0; i < pools[j].poolSize; i++)
    //        {
    //            GameObject obj = Instantiate(pools[j].objectPrefab);
    //            obj.SetActive(false);

    //            pools[j].poolObjects.Enqueue(obj); // siraya ekle 
    //        }
    //    }
    //}
    //public GameObject GetPoolObject(int objectType)
    //{
    //    if (objectType >= pools.Length)
    //    {
    //        return null;
    //    }
    //    GameObject obj = pools[objectType].poolObjects.Dequeue(); // sirali sekilde en bastan objeler geliyor 
    //    obj.SetActive(true);

    //    pools[objectType].poolObjects.Enqueue(obj); // siranin sonuna geri ekledik 

    //    return obj;
    //}

    Queue<GameObject> poolObjects;
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int poolSize;
    [SerializeField] Transform bulletPoint;


    private void Awake() // normal object pool alttaki son yorum satirina kadar 
    {

        poolObjects = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            Quaternion rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
            GameObject obj = Instantiate(objectPrefab, bulletPoint.position, rotation, transform);
            obj.SetActive(false);

            poolObjects.Enqueue(obj); // siraya ekle 
        }
    }
    //public GameObject GetPoolObject()
    //{

    //    GameObject obj = poolObjects.Dequeue(); // sirali sekilde en bastan objeler geliyor 
    //    obj.SetActive(true);

    //    poolObjects.Enqueue(obj); // siranin sonuna geri ekledik 

    //    return obj;
    //}
    public GameObject NewGetPoolObject() // belirledigim range ve sureye uymasi icin gerekli olursa yeni bir obje kendi kendine ekleyecek 
    {
        foreach (GameObject obj in poolObjects)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                poolObjects.Enqueue(obj);
                return obj;
            }
        }
        Quaternion rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
        GameObject newBullet = Instantiate(objectPrefab, bulletPoint.position, rotation, transform);

        newBullet.SetActive(false);
        
        poolObjects.Enqueue(newBullet); // siraya ekle 


        return newBullet;
    }

    // objeleri sirayla acarken range kadar ilerliyorsa elleme ama range kadar gidemiyorsa yeni objeler olusturup siraya ekle 

}
