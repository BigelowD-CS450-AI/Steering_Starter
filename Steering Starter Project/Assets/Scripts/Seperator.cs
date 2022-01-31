using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperator : Kinematic
{
    Separation myMoveType;
    LookWhereGoing myRotateType;
    public Kinematic[] myTargets;

    public bool flee = false; 

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Separation();
        myMoveType.character = this;
        myMoveType.targets = FindObjectsOfType<Kinematic>();

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        Vector3 newPos = transform.position;
        if (transform.position.x > 18)
            newPos.x = -17.5f;
        else if (transform.position.x < -18)
            newPos.x = 17.5f;
        if (transform.position.z > 13.5)
            newPos.z = -13;
        else if (transform.position.z < -13.5)
            newPos.z = 13;
        transform.position = newPos;
        base.FixedUpdate();
    }
}
