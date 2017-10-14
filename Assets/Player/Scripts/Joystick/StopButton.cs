using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StopButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler{

    private float brake = 200;
    public bool isStop = false;

    public void setValueBrake(float brake)
    {
        this.brake = brake;
    }

    public float getValueBrake()
    {
        return this.brake;
    }

    public void setValueIsStop(bool stop)
    {
        this.isStop = stop;
    }

    public bool getValueStop()
    {
        return this.isStop;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        //OnDrag(ped);
        //setValueBrake(50)
        setValueBrake(2);
        setValueIsStop(true);

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        //inputVector = Vector3.zero;
        //joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        setValueBrake(0);
        setValueIsStop(false);
    }



    public float maxHandleBrake()
    {

        return getValueBrake();
    }
}
