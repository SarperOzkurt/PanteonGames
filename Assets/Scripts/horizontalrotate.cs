using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalrotate : MonoBehaviour
{
    [SerializeField] float turnspeed;
    GameObject stickv;
    // Start is called before the first frame update
    void Start()
    {
        stickv = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        stickv.transform.Rotate(0, 20, 0);
    }
}
