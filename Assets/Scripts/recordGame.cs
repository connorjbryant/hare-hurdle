using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateReplay;

public class recordGame : MonoBehaviour
{
    public GameObject recordButton;
    
    public void Record()
    {
        recordButton.SetActive(true);
    }
}
