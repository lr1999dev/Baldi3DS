using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomExtensions
{
    public static float NextRange(this System.Random rng, float min, float max)
    {
        return (float)rng.NextDouble() * (max - min) + min;
    }

    public static T Choice<T>(this T[] array, System.Random rng = null)
    {
        if (rng != null)
            return array[rng.Next(0, array.Length)];
        return array[Random.Range(0, array.Length)];
    }

    public static T Choice<T>(this List<T> list, System.Random rng = null)
    {
        if (rng != null)
            return list[rng.Next(0, list.Count)];
        return list[Random.Range(0, list.Count)];
    }

    public static void Shuffle<T>(this T[] array, System.Random rng = null)
    {
        int n = array.Length;
        while (n > 1)
        {
            n--;

            int k;
            if (rng != null) k = rng.Next(0, array.Length);
            else k = Random.Range(0, array.Length);

            T value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

    public static void Shuffle<T>(this List<T> list, System.Random rng = null)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;

            int k;
            if (rng != null) k = rng.Next(0, list.Count);
            else k = Random.Range(0, list.Count);

            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}