using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject ClickSound;

    public void reveal()
    {
        GameOverMenu.SetActive(true);
        Instantiate(ClickSound);
    }

    public void disable()
    {
        GameOverMenu.SetActive(false);
        Instantiate(ClickSound);
    }
}
