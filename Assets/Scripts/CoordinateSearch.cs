using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSearch : MonoBehaviour
{
    private float _freeSpace = 0.025f;
    private float _widthToWidthRatio;
    private float _lengthToLengthRatio;

    private int _scaleFactor = 10;
    private int _quantityInLength;
    private int _quantityInWidth;

    public int quantityInLength
    {
        get
        {
            return _quantityInLength;
        }
    }

    public int quantityInWidth
    {
        get
        {
            return _quantityInWidth;
        }
    }

    private void Awake()
    {
        DeterminationOfErrorCoefficients();
    }

    private void DeterminationOfErrorCoefficients()
    {
        if (gameObject.transform.parent != null)
        {
            _widthToWidthRatio = gameObject.transform.parent.localScale.x / gameObject.transform.localScale.x;
            _lengthToLengthRatio = gameObject.transform.parent.localScale.z;
        }
        else
        {
            _widthToWidthRatio = 1;
            _lengthToLengthRatio = 1;
        }
    }

    private void CountingTheObstacles(GameObject obstacle)
    {
        float zoneZ = gameObject.transform.localScale.z * _lengthToLengthRatio;
        float zoneX = gameObject.transform.localScale.x * _widthToWidthRatio;
        float obst1Z = obstacle.transform.localScale.z;
        float obst1X = obstacle.transform.localScale.x;

        int longWithoutSpaces = Mathf.FloorToInt(zoneZ / (obst1Z / _scaleFactor));
        int widthWithoutSpaces = Mathf.FloorToInt(zoneX / (obst1X / _scaleFactor));

        _quantityInLength = CountingWithSpaces(zoneZ, obst1Z, longWithoutSpaces);
        _quantityInWidth = CountingWithSpaces(zoneX, obst1X, longWithoutSpaces);

    }

    private int CountingWithSpaces(float zone, float obstacle, int obstaclesWithoutSpaces)
    {
        int count = obstaclesWithoutSpaces;

        for (int i = 0; i < 1000; i++)
        {
            if (zone < (obstacle / _scaleFactor * count) + (_freeSpace * (count - 1)))
            {
                count--;
            }
            else
            {
                break;
            }
        }
        return count;
    }

    public Vector3 DeterminationOfCoordinates(GameObject obstacle)
    {
        float downStartPosition;
        float leftStartPosition;

        float lengthOfTheObstacle = obstacle.transform.localScale.z;
        float widthOfTheObstacle = obstacle.transform.localScale.x;
        float space = obstacle.transform.localScale.z / 2;

        CountingTheObstacles(obstacle);

        if ((_quantityInLength % 2) == 0)
        {
            downStartPosition = (_quantityInLength / 2) * lengthOfTheObstacle + ((_quantityInLength - 1) / 2) * space;
        }
        else
        {
            downStartPosition = (lengthOfTheObstacle / 2 + ((_quantityInLength - 1) / 2) * space + ((_quantityInLength - 1) / 2) * lengthOfTheObstacle);
        }
        if ((_quantityInWidth % 2) == 0)
        {
            leftStartPosition = (_quantityInWidth / 2) * widthOfTheObstacle + ((_quantityInWidth - 1) / 2) * space;
        }
        else
        {
            leftStartPosition = widthOfTheObstacle / 2 + ((_quantityInWidth - 1) / 2) * space + ((_quantityInWidth - 1) / 2) * widthOfTheObstacle;
        }

        return new Vector3(gameObject.transform.position.x + leftStartPosition, obstacle.transform.localScale.y / 2, gameObject.transform.position.z + downStartPosition);
    }
}
