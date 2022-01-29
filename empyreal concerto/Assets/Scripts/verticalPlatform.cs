using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPlatform : MonoBehaviour
{

    private PlatformEffector2D effector;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();//grabs effectior from library
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetButton("Crouch"))//if player hits the Crouch key platform rotates axis to 180
        {
            effector.rotationalOffset = 180f;
        }
        if (Input.GetButton("Jump"))//if player hits the Jump key platform rotates axis to 0
        {
            effector.rotationalOffset = 0f;
        }
    }
}
