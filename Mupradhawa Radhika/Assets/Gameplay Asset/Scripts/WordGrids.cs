using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGrids : MonoBehaviour
{
    public GameData curretGameData;
    public GameObject gridSquarePrefabs;
    public AlphabetData alphabetData;

    public float squareOffset = 0.0f;
    public float topPosition;

    private List<GameObject> _squareList = new List<GameObject>();

    void Start()
    {
        SpawnerGridSquares();
        SetSquaresPosition();
    }

    private void SetSquaresPosition()
    {
        var squareRect = _squareList[0].GetComponent<SpriteRenderer>().sprite.rect;
        var squareTransform = _squareList[0].GetComponent<Transform>();

        var offset = new Vector2
        {
            x = (squareRect.width * squareTransform.localScale.x + squareOffset) * 0.01f,
            y = (squareRect.height * squareTransform.localScale.y + squareOffset) * 0.01f
        };

        var startPosition = GetFirstSquarePosition();
        int columnNumber = 0;
        int rowNUmber = 0;

        foreach (var square in _squareList)
        {
            if (rowNUmber + 1 > curretGameData.selectedBoardData.Rows)
            {
                columnNumber++;
                rowNUmber = 0;
            }

            var positionX = startPosition.x + offset.x + columnNumber;
            var positionY = startPosition.y + offset.y + rowNUmber;

            square.GetComponent<Transform>().position = new Vector2(positionX, positionY);
            rowNUmber++;
        }
    }

    private Vector2 GetFirstSquarePosition()
    {
        var startPosition = new Vector2(0f, transform.position.y);
        var squareRect = _squareList[0].GetComponent<SpriteRenderer>().sprite.rect;
        var squareTrabsform = _squareList[0].GetComponent<Transform>();
        var squareSize = new Vector2(0f, 0f);

        squareSize.x = squareRect.width * squareTrabsform.localScale.x;
        squareSize.y = squareRect.height * squareTrabsform.localScale.y;

        var midWidthPosition = (((curretGameData.selectedBoardData.Columns -1) * squareSize.x) / 2) * 0.01f;
        var midWidthHeight = (((curretGameData.selectedBoardData.Rows -1) * squareSize.y) / 2) * 0.01f;

        startPosition.x = (midWidthPosition != 0) ? midWidthPosition * -2.38f : midWidthPosition;
        startPosition.y = midWidthHeight - 5.78f;

        return startPosition;
    }

    private void SpawnerGridSquares()
    {
        if (curretGameData != null)
        {
            var squareScale = GetSquareScale(new Vector3(0.9f, 0.9f, 0.1f));
            foreach (var squares in curretGameData.selectedBoardData.Board)
            {
                foreach (var squareLetter in squares.Row)
                {
                    var normalLetterData = alphabetData.AlphabetNormal.Find(data => data.letter == squareLetter);
                    var selectedLetterData = alphabetData.AlphabetHighlighted.Find(data => data.letter == squareLetter);
                    var correctLetterData = alphabetData.AlphabetWrong.Find(data => data.letter == squareLetter);

                    if (normalLetterData.image == null || selectedLetterData.image == null)
                    {
                        Debug.LogError("Error TOD, EWEKKKK!!" + squareLetter);

                        #if UNITY_EDITOR

                        if (UnityEditor.EditorApplication.isPlaying)
                        {
                            UnityEditor.EditorApplication.isPlaying = false;
                        }
                        #endif
                    }

                    else
                    {
                        _squareList.Add(Instantiate(gridSquarePrefabs));
                        _squareList[_squareList.Count - 1].GetComponent<GridSquare>().SetSprite(normalLetterData, correctLetterData, selectedLetterData);
                        _squareList[_squareList.Count - 1].transform.SetParent(this.transform);
                        _squareList[_squareList.Count - 1].GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
                        _squareList[_squareList.Count - 1].transform.localScale = squareScale;
                        _squareList[_squareList.Count - 1].GetComponent<GridSquare>().SetIndex(_squareList.Count - 1);
                    }
                }
            }
        }
    }

    private Vector3 GetSquareScale(Vector3 defaultScale)
    {
        var finalScale = defaultScale;
        var adjusment = 0.01f;

        while (ShouldScaleDown(finalScale))
        {
            finalScale.x -= adjusment;
            finalScale.y -= adjusment;

            if (finalScale.x <= 0 || finalScale.y <= 0)
            {
                finalScale.x = adjusment;
                finalScale.y = adjusment;
                return finalScale;
            }
        }

        return finalScale;
    }

    private bool ShouldScaleDown(Vector3 targetScale)
    {
        var squareRect = gridSquarePrefabs.GetComponent<SpriteRenderer>().sprite.rect;
        var squareSize = new Vector2(0f, 0f);
        var startPosition = new Vector2(0f, 0f);

        squareSize.x = (squareRect.width * targetScale.x) + squareOffset;
        squareSize.y = (squareRect.height * targetScale.y) + squareOffset;


        var midWidthPosition = ((curretGameData.selectedBoardData.Columns * squareSize.x) / 2) * 0.01f;
        var midWidthHeight = ((curretGameData.selectedBoardData.Rows * squareSize.y) / 2) * 0.01f;

        startPosition.x = (midWidthPosition != 0) ? midWidthPosition * -1 : midWidthPosition;
        startPosition.y = midWidthHeight;

        return (startPosition.x < GetHalfScreenWidth() * -1 || startPosition.y > topPosition);
    }

    private float GetHalfScreenWidth()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = (1.7f * height) * Screen.width / Screen.height;
        return width / 2;
    }
}
