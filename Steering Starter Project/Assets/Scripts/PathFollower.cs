using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : Seeker
{
    //distance of "collision"
    [SerializeField] private const float pathMarketCollectDistance = 0.5f;
    protected override void FixedUpdate()
    {
        //if distance between this and marker is less than defined distance, move marker to next location
        if (Vector3.Distance(myTarget.transform.position, gameObject.transform.position) < pathMarketCollectDistance)
            myTarget.GetComponent<Path_Borders>().CharacterReachedPathMarker();
        //call seekr's movement behavior
        base.FixedUpdate();
    }
}
