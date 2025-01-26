using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEventHandler : MonoBehaviour
{
    public static event Action OnBulletHitWithInteractableObject;
    public static event Action OnSelected;
    public static event Action OnGivenAmmo;
    public static event Action OnUseAmmo;
    public static GameObject savedInteractable;

    public static void NotifyInteractedWith()
    {
        OnBulletHitWithInteractableObject?.Invoke();
    }

    public static GameObject NotifySelected(GameObject gameObject)
    {
        savedInteractable = gameObject;
        OnSelected?.Invoke();
        return savedInteractable;
    }

    public static void GiveAmmonition()
    {
        OnGivenAmmo?.Invoke();
    }

    public static void UseAmmonition()
    {
        OnUseAmmo?.Invoke();
    }
}
