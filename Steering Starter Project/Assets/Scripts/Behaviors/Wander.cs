using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehavior
{
    public Kinematic character;
    private Vector3 targetPosition;
    public GameObject target;
    float maxAcceleration = 100f;

    private const float wanderRadius = 5.0f;

    private void GenerateTargetPosition()
    {
        float randomRotation = Random.value * 2 * Mathf.PI;
        targetPosition = new Vector3(Mathf.Cos(randomRotation), 0, Mathf.Sin(randomRotation)) * 2;
        targetPosition.x += 2;
        targetPosition = character.transform.position + targetPosition;
        target.transform.position = targetPosition;
    }

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        if (targetPosition == Vector3.zero|| (character.transform.position - targetPosition).magnitude < 0.5f)
            GenerateTargetPosition();
        if (targetPosition == Vector3.positiveInfinity)
        {
            return null;
        }

        //result.linear = target.transform.position - character.transform.position;
        result.linear = targetPosition - character.transform.position;

        // give full acceleration along this direction
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
    }
}
