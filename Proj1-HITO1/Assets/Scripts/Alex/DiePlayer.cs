using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.SetPlayer(this.gameObject);
    }

    public void Call()
    {
        Destroy(this.gameObject);
    }
}
