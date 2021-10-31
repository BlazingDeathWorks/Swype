using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField]
    GameObject[] disables;

    public void EnableTabs()
    {
        //Enables
        gameObject.SetActive(true);

        //Disables
        foreach (GameObject gameObjects in disables)
        {
            gameObjects.SetActive(false);
        }
    }
}
