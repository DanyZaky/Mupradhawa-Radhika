using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingWrodsList : MonoBehaviour
{
    public GameData currectGameData;
    public GameObject searhingWordPrefabs;
    public GameObject buttonAttackDisable;
    public float offset = 0.0f;
    public int maxColumns = 5;
    public int maxRows = 4;

    private int _columns = 2;
    private int _rows;
    private int _wordNumber;

    private List<GameObject> _words = new List<GameObject>();
    private void Start()
    {
        _wordNumber = currectGameData.selectedBoardData.SearchWords.Count;

        if (_wordNumber < _columns)
        {
            _rows = 1;
        }
        else
        {
            CalculateColumnsAndRowsNumber();
        }

        CreateWordObjects();
        SetWordPosition();
    }

    private void CalculateColumnsAndRowsNumber()
    {
        do
        {
            _columns++;
            _rows = _wordNumber / _columns;
        } while (_rows > -maxRows);

        if (_columns > maxColumns)
        {
            _columns = maxColumns;
            _rows = _wordNumber / _columns;
        }
    }

    private bool TryIncreaseColumnNumber()
    {
        _columns++;
        _rows = _wordNumber / _columns;

        if (_columns > maxColumns)
        {
            _columns = maxColumns;
            _rows = _wordNumber / _columns;

            return false;
        }

        if (_wordNumber %  _columns > 0)
        {
            _rows++;
        }

        return true;
    }

    private void CreateWordObjects()
    {
        var squareScale = GetSquareScale(new Vector3(1f, 1f, 0.1f));

        for (var index = 0; index < _wordNumber; index++)
        {
            _words.Add(Instantiate(searhingWordPrefabs) as GameObject);
            _words[index].transform.SetParent(this.transform);
            _words[index].GetComponent<RectTransform>().localScale = squareScale;
            _words[index].GetComponent<RectTransform>().localPosition = new Vector3 (0f,0f,0f);
            _words[index].GetComponent<SearchingWord>().SetWord(currectGameData.selectedBoardData.SearchWords[index].Word);
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

    private bool ShouldScaleDown (Vector3 targetScale)
    {
        var squareRect = searhingWordPrefabs.GetComponent<RectTransform>();
        var parentRect = this.GetComponent<RectTransform>();

        var squareSize = new Vector2(0f, 0f);

        squareSize.x = squareRect.rect.width * targetScale.x + offset;
        squareSize.y = squareRect.rect.height * targetScale.y + offset;

        var totalSquareHeight = squareSize.y * _rows;

        //--

        if (totalSquareHeight > parentRect.rect.height)
        {
            while (totalSquareHeight > parentRect.rect.height)
            {
                if (TryIncreaseColumnNumber())
                {
                    totalSquareHeight = squareSize.y * _rows;
                }
                else
                {
                    return true;
                }
            }
        }

        var totalSquareWidth = squareSize.x * _columns;

        if (totalSquareHeight > parentRect.rect.width)
        {
            return true;
        }
        return false;
    }

    private void SetWordPosition()
    {
        var squareRect = _words[0].GetComponent<RectTransform>();
        var wordOffset = new Vector2
        {
            x = squareRect.rect.width * squareRect.transform.localScale.x + offset,
            y = squareRect.rect.height * squareRect.transform.localScale.y + offset
        };

        int columnNumber = 0;
        int rowNumber = 0;
        var startPosition = GetFirstSquarePosition();

        foreach(var word in _words)
        {
            if (columnNumber + 1 > _columns)
            {
                columnNumber = 0;
                rowNumber++;
            }

            var positionX = startPosition.x + wordOffset.x * columnNumber;
            var positionY = startPosition.y + wordOffset.y * rowNumber;

            word.GetComponent<RectTransform>().localPosition = new Vector2(positionX, positionY);
            columnNumber++;
        }

    }

    private Vector2 GetFirstSquarePosition()
    {
        var startPosition = new Vector2(0f, transform.position.y);
        var squareRect = _words[0].GetComponent<RectTransform>();
        var parentRect = this.GetComponent<RectTransform>();
        var squareSize = new Vector2(0f, 0f);

        squareSize.x = squareRect.rect.width * squareRect.transform.localScale.x + offset;
        squareSize.y = squareRect.rect.height * squareRect.transform.localScale.y + offset;


        //--

        var shiftBy = (parentRect.rect.width - (squareSize.x * _columns)) / 2;

        startPosition.x = ((parentRect.rect.width - squareSize.x) / 2) * (-1);
        startPosition.x += shiftBy;
        startPosition.y = (parentRect.rect.height - squareSize.y) / 2;

        return startPosition;
    }
}
