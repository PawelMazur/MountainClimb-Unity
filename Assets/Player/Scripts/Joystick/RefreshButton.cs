using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RefreshButton : MonoBehaviour, IPointerClickHandler{

	private bool click = false;

    public void isClick(bool click)
    {
        this.click = click;
    }

    public bool isClick()
    {
        return click;
    }



    
    public void OnPointerClick(PointerEventData eventData)
    {
        print("true");
        isClick(true);
    }

}
