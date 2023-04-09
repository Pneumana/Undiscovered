using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolLooting : MonoBehaviour
{
    public GolemAdvance golem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //trigger for player touching this object


    //this function should be triggered via an AnimationEvent in the loot idol animation
    public void ActivateGolem()
    {
        golem.isActive = true;
    }
}
