using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager instance;
    public static System.Action OnUpdate;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
            if (OnUpdate != null)
                OnUpdate();
    }
}
