using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckColision : MonoBehaviour
{
    private bool onTriggerStayF = false;
    private bool onTriggerStayJ = false;
    private bool destroy = false;
    private void Update()
    {
        FuckingSystemPlayerFrendly(onTriggerStayF, Input.GetKeyDown(KeyCode.F));
        FuckingSystemPlayerFrendly(onTriggerStayJ, Input.GetKeyDown(KeyCode.J));
    }

    private void FuckingSystemPlayerFrendly(bool onTriggerStay, bool keyDown)
    {
        if (onTriggerStay)
        {
                if (keyDown)
                {
                    destroy = true;
                }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.position.y == 2) onTriggerStayF = true;
        if (collision.transform.position.y == -2) onTriggerStayJ = true;
     
        if (destroy)
        {
            Destroy(collision.gameObject);
            destroy = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.position.y == 2) onTriggerStayF=false;
        if (collision.transform.position.y == -2) onTriggerStayJ=false;
    }
}
