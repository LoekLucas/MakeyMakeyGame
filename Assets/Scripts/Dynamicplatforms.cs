using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dynamicplatforms : MonoBehaviour
{
    public float internalTimer = 0;
    bool platformExists = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer += Time.deltaTime;

        if ( internalTimer % 4 == 0 )
        {
            if (platformExists == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.x - 1);
                platformExists = false;

            }

            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.x + 1);
                platformExists = true;
            }
        }
    }
}
