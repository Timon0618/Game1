using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson : MonoBehaviour
{
    public int[] Values = new int[3] { 1, 2, 3 };





    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Values.Length; i++)
        {
            Debug.Log(Values[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
