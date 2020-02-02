using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillingZones : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyObstacle2;

    [SerializeField]
    private CoordinateSearch _coordinateSearch;
    [SerializeField]
    private FillingOptions _fillingOptions;

    void Start()
    {
        Filing();
    }

    private void Filing()
    {
        Vector3 startCoordinates = _coordinateSearch.DeterminationOfCoordinates(_enemyObstacle2);

        int length = _coordinateSearch.quantityInLength;
        int width = _coordinateSearch.quantityInWidth;

        int rand = Random.Range(1, 6);

        switch (rand)
        {
            case 1:
                _fillingOptions.Variant1(startCoordinates, length, width);
                break;
            case 2:
                _fillingOptions.Variant2(startCoordinates, length, width);
                break;
            case 3:
                _fillingOptions.Variant3(startCoordinates, length, width);
                break;
            case 4:
                _fillingOptions.Variant4(startCoordinates, length, width);
                break;
            case 5:
                _fillingOptions.Variant5(startCoordinates, length, width);
                break;
        }

        gameObject.transform.SetParent(GameObject.Find("Floor").transform);
    }
}
