using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UseObject : MonoBehaviour
{
    public abstract void UnUse();
    public abstract void UseReady();
    public abstract void Idle();
    public abstract void Use();
}
