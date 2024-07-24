using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public static event Action ExampleEvent;

    public static event Action DeckEvent;

    public static event Action<int> MoveCardEvent;

    public static event Action<float> EndTimer;

    public static event Action<int> UseMana;

    public static event Action<int> TrackMana;

    public static event Action<int> TrackHP;

    public static event Action<int> TrackMaxHP;

    public static event Action<int> TrackMaxMana;

    public static event Action<int> TrackDamage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }

    public static void DrawCards()
    {
        ExampleEvent?.Invoke();

    }

    public static void RemoveCard()
    {
        DeckEvent?.Invoke();
    }

    public static void MoveCardToBottom(int i)
    {
        MoveCardEvent?.Invoke(i);
    }

    public static void EndGame(float f)
    {
        EndTimer?.Invoke(f);
    }

    public static void ReduceMana(int i)
    {
        UseMana?.Invoke(i);
    }

    public static void trackMana(int i)
    {
        TrackMana?.Invoke(i);
    }

    public static void trackHP(int i)
    {
        TrackHP?.Invoke(i);
    }

    public static void trackMaxHP(int i)
    {
        TrackMaxHP?.Invoke(i);
    }

    public static void trackMaxMana(int i)
    {
        TrackMaxMana?.Invoke(i);
    }

    public static void trackDamage(int i)
    {
        TrackDamage?.Invoke(i);
    }

}
