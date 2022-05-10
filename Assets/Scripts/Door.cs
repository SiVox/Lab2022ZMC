using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform
        closePosition,
        openPosition,
        door;

    public bool open = false;

    int speed = 5;

   
    void Start()
    {
        door.position = closePosition.position;
    }

    
    void Update()
    {
        if(open && Vector3.Distance(door.position,openPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, Time.deltaTime * speed);
        }
        if (!open && Vector3.Distance(door.position, closePosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, closePosition.position, Time.deltaTime * speed);
        }

    }

    public void OpenClose()
    {
        open = !open;
    }
}
