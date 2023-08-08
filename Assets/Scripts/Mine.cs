using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mine : MonoBehaviour
{
    public int amountIncome = 50;
    public int amountWorkers = 0;
    public int maxWorkerCount = 3;
    public Button button;


    private void Start()
    {
        button.onClick.AddListener(AddWorker);
    }

    public void AddWorker()
    {
        if(amountWorkers < maxWorkerCount) amountWorkers++;
    }


    private void OnMouseDown()
    {
        //ShowButton();
    }

/*    private void ShowButton()
    {
        button.gameObject.SetActive(true);
    }

    private void HideButton()
    {
        button.gameObject.SetActive(false);
    }*/

/*    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.lastPress != this.gameObject) HideButton();
    }

    private void OnMouseDown()
           Vector3 mousePosition = Input.mousePosition;
    Vector3 buttonPosition = Camera.main.WorldToScreenPoint(transform.position);
        
        if (Vector2.Distance(mousePosition, buttonPosition) > someThreshold)
                   isVisible = false;
            gameObject.SetActive(false);*/
}
