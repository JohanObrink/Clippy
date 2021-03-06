﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class LoopingExtensions
{
    /// <summary>
    /// Runs the provided action for each of the items in the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static IEnumerable<T> Each<T>(this IEnumerable<T> collection, Action<T> action)
    {
        if (collection == null)
            throw new ArgumentNullException("collection");

        foreach (T item in collection)
            action(item);

        return collection;
    }

    /// <summary>
    /// Runs the action the provided amount of times
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="action"></param>
    public static void Times(this int amount, Action<int> action)
    {
        if (amount < 0)
            throw new ArgumentException("What ARE you doing? Can't run the action a negative amount of times");

        if (action == null)
            throw new ArgumentNullException("action");

        for (var i = 0; i < amount; i++)
            action(i);
    }
}