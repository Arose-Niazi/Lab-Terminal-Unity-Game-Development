using System;
using UnityEngine;

public class PlaneHandler : MonoBehaviour
{
    public GameObject[] planes;
    public GameObject[] grounds;
    public Vector3 sizeToAdd;
    
    void Update()
    {
        var currentPos = planes[planes.Length - 1].transform.position.z;
        if (currentPos - 5 < transform.position.z)
        {
            var newPos = planes[planes.Length-1].transform.position;
            var groundPos = newPos;
            groundPos -= Vector3.down;
            for (int i = 0; i < planes.Length-1; i++)
            {
                newPos += sizeToAdd;
                groundPos += sizeToAdd;
                planes[i].transform.position = newPos;
                grounds[i].transform.position = groundPos;
            }

            Array.Sort(planes, CompareZ);
            Array.Sort(grounds, CompareZ);

        }
    }

    int CompareZ(GameObject x, GameObject y)
    {
        return x.transform.position.z.CompareTo(y.transform.position.z);
    }
}
