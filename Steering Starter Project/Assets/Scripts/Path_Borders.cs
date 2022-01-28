using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Saves a set of array positions that the parent path
//marker object can go to and their order
public class Path_Borders : MonoBehaviour
{
    //public bool flee = false;
    [SerializeField] private Vector3[] path = new Vector3[8];
    [SerializeField] private int curPathindex = 0;
    private float pathScalar = 10.0f;

    public void Start()
    {
        //initialize path
        path[0] = new Vector3(1, 0, 0) * pathScalar;
        path[1] = new Vector3(1, 0, 1) * pathScalar;
        path[2] = new Vector3(0, 0, 1) * pathScalar;
        path[3] = new Vector3(-1, 0, 1) * pathScalar;
        path[4] = new Vector3(-1, 0, 1) * pathScalar;
        path[5] = new Vector3(-1, 0, 0) * pathScalar;
        path[6] = new Vector3(-1, 0, -1) * pathScalar;
        path[7] = new Vector3(0, 0, -1) * pathScalar;
        path[7] = new Vector3(1, 0, -1) * pathScalar;
        gameObject.transform.position = path[0];
    }

    public void CharacterReachedPathMarker()
    {
        curPathindex = (curPathindex + 1) % path.Length;
        gameObject.transform.position = path[curPathindex];
    }
}
