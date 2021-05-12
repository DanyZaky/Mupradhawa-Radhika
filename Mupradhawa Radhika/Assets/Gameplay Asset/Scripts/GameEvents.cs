using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public delegate void EnableSquareSelection();
    public static event EnableSquareSelection OnEnableSquareSelection;
    public static void EnableSquareSelectionMethod()
    {
        if (OnEnableSquareSelection != null)
        {
            OnEnableSquareSelection();
        }
    }

    //--
    public delegate void DisableSquareSelection();
    public static event DisableSquareSelection OnDisableSquareSelection;

    public static void DisableSquareSelectionMethod()
    {
        if (OnDisableSquareSelection != null)
        {
            OnDisableSquareSelection();
        }
    }
    //--

    public delegate void SelectSquare(Vector3 position);
    public static event SelectSquare OnSelectSuare;

    public static void SelectSquareMethod(Vector3 position)
    {
        if (OnSelectSuare != null)
        {
            OnSelectSuare(position);
        }
    }
    //--

    public delegate void CheckSquare(string letter, Vector3 squarePosition, int sqaureIndex);
    public static event CheckSquare OnCheckSquare;

    public static void CheckSquareMethod(string letter, Vector3 squarePosition, int sqaureIndex)
    {
        if (OnCheckSquare != null)
        {
            OnCheckSquare(letter, squarePosition, sqaureIndex);
        }
    }
    //--

    public delegate void ClearSelection();
    public static event ClearSelection OnClearSelection;

    public static void ClearSelectionMethod()
    {
        if (OnClearSelection != null)
        {
            OnClearSelection();
        }
    }
    //--

    public delegate void CorrectWord(string word, List<int> squareIndexes);
    public static event CorrectWord OnCorrectWord;
    public static void CorrectWOrdMethod(string word, List<int> squareIndexes)
    {
        if (OnCorrectWord != null)
        {
            OnCorrectWord(word, squareIndexes);
        }
    }
    //--
}
