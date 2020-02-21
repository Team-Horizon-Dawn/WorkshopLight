using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trap : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;

    public float speed;
    
    private bool activated;

    UnityEvent eventTrap;
    
    void Start()
    {
        activated = false;
     
        rigidbody = GetComponent<Rigidbody>();

        if (eventTrap == null)
        {
            eventTrap = new UnityEvent();
        }
        eventTrap.AddListener(activate);
    }

    // Update is called once per frame
    void Update()
    {
        // Demo purposes
        if (Input.anyKeyDown && eventTrap != null)
        {
            eventTrap.Invoke();
        }
    }

    private void FixedUpdate() {
        if(activated)
        {
            clap();
        }
    }

    private void clap()
    {
        if (rigidbody.transform.rotation.eulerAngles.z > 260  ||  rigidbody.transform.rotation.eulerAngles.z < 89.9)
        {
            rigidbody.MoveRotation(rigidbody.rotation *  Quaternion.Euler(transform forward * speed));
        }

    }

    private void activate()
    {
        activated = true;
    }
}
