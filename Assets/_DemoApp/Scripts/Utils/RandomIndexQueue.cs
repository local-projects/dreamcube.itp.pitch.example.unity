using System.Collections.Generic;
using UnityEngine;

public class RandomIndexQueue
{
    private int _listLength;
    private Queue<int> _randomIndexQueue;

    public RandomIndexQueue(int listLength)
    {
        this._listLength = listLength;
        RefillRandomIndexQueue();
    }

    private void RefillRandomIndexQueue()
    {
        List<int> randomIndexList = new List<int>();
        for (int i = 0; i < _listLength; i++)
        {
            randomIndexList.Add(i);
        }
        randomIndexList.Shuffle();

        _randomIndexQueue = new Queue<int>(randomIndexList);
    }

    public int GetRandomIndex()
    {
        if (_randomIndexQueue.Count == 0)
        {
            RefillRandomIndexQueue();
        }

        return _randomIndexQueue.Dequeue();
    }

    public void PrintQueue()
    {
        string output = "";
        foreach (int i in _randomIndexQueue)
        {
            output += i + " ";
        }
        Debug.Log(output);
    }
}