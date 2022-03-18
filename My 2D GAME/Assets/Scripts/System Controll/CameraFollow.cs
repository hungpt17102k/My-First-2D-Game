using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Func<Vector3> GetCameraFollowPosFunc;

    //ham cho camera theo nhan vat
    public void Setup(Func<Vector3> GetCameraFollowPosFunc)
    {
        this.GetCameraFollowPosFunc = GetCameraFollowPosFunc;
    }

    //giong ham tren cung cho camre theo nhan vat (viet 2 ham de goi ro rang hon nhung chuc nang thi giong nhau)
    public void SetGetCameraFollowPosFunc(Func<Vector3> GetCameraFollowPosFunc)
    {
        this.GetCameraFollowPosFunc = GetCameraFollowPosFunc;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraFollowPos = GetCameraFollowPosFunc();
        cameraFollowPos.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPos - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPos, transform.position);
        float cameraMoveSpeed = 3f;

        if(distance > 0)
        {
            Vector3 newCameraPos = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

            float distanceAfterMoving = Vector3.Distance(newCameraPos, cameraFollowPos);
            
            if(distanceAfterMoving > distance)
            {
                //Overshot the target
                newCameraPos = cameraFollowPos;
            }

            transform.position = newCameraPos;
        }

       
    }
}
