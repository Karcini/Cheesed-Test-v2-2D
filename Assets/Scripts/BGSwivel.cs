using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSwivel : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;
    public Vector3 shiftInPosition;
    public Vector3 camPosition;
    public Vector3 targetPos;
    Vector3 displacement;
    float speed = 1f;
    bool hasTarget = false;

    void Update()
    {
        MoveObject();
    }
    void MoveObject()
    {
        //Get current camera position
        camPosition = mainCam.transform.position;
        camPosition.z = 0;

        //If you do not have a target, set a target displacement
        if (!hasTarget)
        {
            Debug.Log("new target");
            targetPos = SetNewTargetPosition();
            hasTarget = true;
        }

        //Shift in position is the camera position + displacement
        DisplacementToTarget();

        //Move this object to the shifted camera position
        this.gameObject.transform.position = shiftInPosition;
    }
    void DisplacementToTarget()
    {
        float dt = Time.deltaTime;
        displacement = Vector3.MoveTowards(displacement, targetPos, speed * dt);
        if (displacement == targetPos)
        {
            hasTarget = false;
        }
        shiftInPosition = camPosition + displacement;
    }
    Vector3 SetNewTargetPosition()
    {
        float z = 0f;
        float x = Random.Range(-4.5f, 4.5f);
        float y = Random.Range(-5.5f, 5.5f);

        Vector3 newVec = new Vector3(x, y, z);
        return newVec;
    }
}
