using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RetreatButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler{

    private float maxTorque = 0;
    public bool isSpeed = false;


    public void setValueSpeed(bool speed)
    {
        this.isSpeed = speed;
    }

    public bool getValueSpeed()
    {
        return this.isSpeed;
    }

    public void setValueTorque(float maxTorque)
    {
        this.maxTorque = maxTorque;
    }

    public float getValueTorque()
    {
        return this.maxTorque;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        //OnDrag(ped);
        setValueTorque(-1);
        setValueSpeed(true);

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        //inputVector = Vector3.zero;
        //joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        setValueTorque(0);
        setValueSpeed(false);
    }



    public float Horizontal()
    {
        return getValueTorque();
    }
}
