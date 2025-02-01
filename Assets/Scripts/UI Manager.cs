using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    // Start is called before the first frame update
    void OnEnable()
    {
        GameplayEventsHandeler.GameStarted += HideUI;
    }

    private void OnDisable()
    {
        GameplayEventsHandeler.GameStarted -= HideUI;
    }

    // Update is called once per frame
    void HideUI()
    {
        gameObject.SetActive(false);
    }
}
