using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLever : MonoBehaviour
{
    public GameObject[] resetObjects;
    public List<Vector3> resetPositions = new List<Vector3>();
    public bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        resetPositions.Clear();
        //resetObjects = GameObject.FindGameObjectsWithTag("Moveable");
        foreach(GameObject obj in resetObjects)
        {
            resetPositions.Add(obj.transform.position);
        }
    }
    public void ResetAll()
    {
        Debug.Log("resetting puzzle");
        if (!disabled)
        {
            for(int i = 0; i < resetObjects.Length; i++)
            {
                resetObjects[i].transform.position = resetPositions[i];
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            ResetAll();
        }
    }
}
