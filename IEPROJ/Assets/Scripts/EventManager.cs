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
}
