using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    GameObject drone;
    public VictorSierraMovement parentScript;
    // Start is called before the first frame update
    void Start()
    {
        parentScript= GetComponentInParent<VictorSierraMovement>();
        int numDrones = 4;
        //for (int i = 0; i < numDrones; ++i) {
            GameObject newCircle = Instantiate(drone, transform.position,Quaternion.identity);

            newCircle.transform.localScale = new Vector3(2f,2f,2f);
        //}
        parentScript.initialized=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
