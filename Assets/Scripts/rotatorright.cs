using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatorright : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float turnspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnspeed * Time.deltaTime);
    }
}
