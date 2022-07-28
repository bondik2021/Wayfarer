using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanTakeDamage
{
    public enum States{Мертв, Атака, Патруль}
    public void TakeDamage(int value);
    public void Die();
    public States GetCurrentUnitState();
}
