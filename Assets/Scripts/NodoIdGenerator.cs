using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoIdGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Nodo>().setId(i);
        }
    }
}
