using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    void Awake()
    {
        Program.Instance.RegisterProp(this);
    }
}