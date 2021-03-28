// Authors: Ellie McDonald, Lance Graham, Trevor West and Rebecca Henry
// 03/28/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    void Notify();
    void AddObserver(IObserver anObserver);
    void RemoveObserver(IObserver anObserver);
}
