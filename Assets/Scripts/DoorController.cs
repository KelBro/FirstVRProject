using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private PressurePlate button1;
    
    [SerializeField]
    private PressurePlate button2;

    [SerializeField]
    private TeleportArea teleZone;

    private Coroutine currentAnimation = null;

    private const float CloseY = 1.29f;
    private const float OpenY = 4.55f;
    private const float Speed = (4.55f - 1.29f) / 270;

    private bool opening = false;

    // Update is called once per frame
    void Update()
    {
        if (button1.correct && button2.correct)
        {
            if (currentAnimation == null || !opening)
            {
                if (currentAnimation != null) 
                { 
                    StopCoroutine(currentAnimation); 
                }
                currentAnimation = StartCoroutine(DoorAnimation(Speed));
                teleZone.locked = false;
                opening = true;
            }
            
        }
        else if (!teleZone.locked)
        {
            if (currentAnimation == null || opening)
            {
                if (currentAnimation != null) 
                {
                    StopCoroutine(currentAnimation); 
                }
                currentAnimation = StartCoroutine(DoorAnimation(-Speed));
                teleZone.locked = true;
                opening = false;
            }
        }
    }

    private IEnumerator DoorAnimation(float speed)
    {
        print("Animation started!");
        if (speed > 0) {
            while (transform.position.y < OpenY)
            {
                print("Opening!");
                transform.Translate(new Vector3(0f, speed, 0f));
                yield return null;
            }
        }
        else
        {
            while (transform.position.y > CloseY)
            {
                print("Closing!");
                transform.Translate(new Vector3(0f, speed, 0f));
                yield return null;
            }
        }
        print("Coroutine complete!");
    }
}
