using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    void Awake()
    {
        Program.Instance.Props.Add(this);
    }
    
    public void Die()
    {
        Program.Instance.Props.Remove(this);
        Destroy(this.gameObject);
    }

}