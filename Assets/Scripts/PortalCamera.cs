using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform
        playerCamera,
        portal,
        otherPortal;
    float myAngle;

    void PortalCameraController()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

        transform.position = portal.position + playerOffsetFromPortal;

        float angularDBPR = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        if(myAngle == 90 || myAngle == 270)
        {
            angularDBPR -= 90;
        }

        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDBPR, Vector3.up);

        Vector3 newCameraDir = portalRotDiff * playerCamera.forward;

        if(myAngle==90 || myAngle == 270)
        {
            newCameraDir = new Vector3(newCameraDir.z * -1, newCameraDir.y * 1, newCameraDir.x * 1);
            transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
        }
        else
        {
            newCameraDir = new Vector3(newCameraDir.x * -1, newCameraDir.y * 1, newCameraDir.z * -1);
            transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
        }
    }

    public void SetMyAngle(float angle)
    {
        myAngle = angle;
    }
}
