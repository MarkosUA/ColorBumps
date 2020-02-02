using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillingOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyObstacle1;
    [SerializeField]
    private GameObject _enemyObstacle2;
    [SerializeField]
    private GameObject _enemyObstacle3;
    [SerializeField]
    private GameObject _enemyObstacle4;

    [SerializeField]
    private GameObject _wideObstacle;

    [SerializeField]
    private GameObject _friendObstacle1;
    [SerializeField]
    private GameObject _friendObstacle2;
    [SerializeField]
    private GameObject _friendObstacle3;
    [SerializeField]
    private GameObject _friendObstacle4;

    private GameObject PrefabSelection(string type)
    {
        int rand = Random.Range(1, 4);

        if (type == "Enemy")
        {
            switch (rand)
            {
                case 1:
                    return _enemyObstacle1;
                case 2:
                    return _enemyObstacle2;
                case 3:
                    return _enemyObstacle3;
                case 4:
                    return _enemyObstacle4;
                default:
                    return null;
            }
        }
        else
        {
            switch (rand)
            {
                case 1:
                    return _friendObstacle1;
                case 2:
                    return _friendObstacle2;
                case 3:
                    return _friendObstacle3;
                case 4:
                    return _friendObstacle4;
                default:
                    return null;
            }
        }
    }

    public void Variant1(Vector3 startCoordinates, int length, int width)
    {
        var coordinates = startCoordinates;

        GameObject enemyObstacle = PrefabSelection("Enemy");
        GameObject friendObstacle = PrefabSelection("Friend");

        int friendStartPosition = Random.Range(1, width);
        int friendWidth = Random.Range(2, width - friendStartPosition + 1);

        for (int i = length; i > 0; i--)
        {
            coordinates.x = startCoordinates.x;
            for (int j = width; j > 0; j--)
            {
                if (j >= friendStartPosition && j <= friendStartPosition + friendWidth)
                {
                    var cloneObstacle = Instantiate(friendObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= friendObstacle.transform.localScale.x + friendObstacle.transform.localScale.x / 2;
                }
                else
                {
                    var cloneObstacle = Instantiate(enemyObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= enemyObstacle.transform.localScale.x + enemyObstacle.transform.localScale.x / 2;
                }
            }
            coordinates.z -= enemyObstacle.transform.localScale.z + enemyObstacle.transform.localScale.z / 2;
        }
    }

    public void Variant2(Vector3 startCoordinates, int length, int width)
    {
        var coordinates = startCoordinates;

        GameObject enemyObstacle = PrefabSelection("Enemy");
        GameObject friendObstacle = PrefabSelection("Friend");

        int friendStartPosition = Random.Range(2, Mathf.FloorToInt(length * 2 / 5) + 1);
        int friendWidth = length - friendStartPosition;

        for (int i = length; i > 0; i--)
        {
            coordinates.x = startCoordinates.x;
            for (int j = width; j > 0; j--)
            {
                if (i >= friendStartPosition && i <= friendStartPosition + friendWidth)
                {
                    var cloneObstacle = Instantiate(friendObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= friendObstacle.transform.localScale.x + friendObstacle.transform.localScale.x / 2;
                }
                else
                {
                    var cloneObstacle = Instantiate(enemyObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= enemyObstacle.transform.localScale.x + enemyObstacle.transform.localScale.x / 2;
                }
            }
            coordinates.z -= enemyObstacle.transform.localScale.z + enemyObstacle.transform.localScale.z / 2;
        }
    }

    public void Variant3(Vector3 startCoordinates, int length, int width)
    {
        var coordinates = startCoordinates;

        int friendStartPosition = Random.Range(2, Mathf.FloorToInt(length * 2 / 5) + 1);
        int friendWidth = length - friendStartPosition;

        for (int i = length; i > 0; i--)
        {
            coordinates.x = startCoordinates.x;
            for (int j = width; j > 0; j--)
            {
                if (i >= friendStartPosition && i <= friendStartPosition + friendWidth)
                {
                    GameObject friendObstacle = PrefabSelection("Friend");

                    var cloneObstacle = Instantiate(friendObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= friendObstacle.transform.localScale.x + friendObstacle.transform.localScale.x / 2;
                }
                else
                {
                    GameObject enemyObstacle = PrefabSelection("Enemy");

                    var cloneObstacle = Instantiate(enemyObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= enemyObstacle.transform.localScale.x + enemyObstacle.transform.localScale.x / 2;
                }
            }
            coordinates.z -= _enemyObstacle1.transform.localScale.z + _enemyObstacle1.transform.localScale.z / 2;
        }
    }

    public void Variant4(Vector3 startCoordinates, int length, int width)
    {
        var coordinates = startCoordinates;

        int friendStartPosition = Random.Range(1, width);
        int friendWidth = Random.Range(2, width - friendStartPosition + 1);

        for (int i = length; i > 0; i--)
        {
            coordinates.x = startCoordinates.x;
            for (int j = width; j > 0; j--)
            {
                if (j >= friendStartPosition && j <= friendStartPosition + friendWidth)
                {
                    GameObject friendObstacle = PrefabSelection("Friend");
                    var cloneObstacle = Instantiate(friendObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= friendObstacle.transform.localScale.x + friendObstacle.transform.localScale.x / 2;
                }
                else
                {
                    GameObject enemyObstacle = PrefabSelection("Enemy");
                    var cloneObstacle = Instantiate(enemyObstacle, coordinates, Quaternion.identity);
                    cloneObstacle.transform.SetParent(gameObject.transform);
                    coordinates.x -= enemyObstacle.transform.localScale.x + enemyObstacle.transform.localScale.x / 2;
                }
            }
            coordinates.z -= _enemyObstacle1.transform.localScale.z + _enemyObstacle1.transform.localScale.z / 2;
        }
    }

    public void Variant5(Vector3 startCoordinates, int length, int width)
    {
        var coordinates = startCoordinates;
        float widthOfTheWideObstacle = Random.Range(4, 7);
        GameObject enemyObstacle = PrefabSelection("Enemy");

        for (int i = length; i > 0; i--)
        {
            coordinates.x = startCoordinates.x;
            for (int j = width; j > 0; j--)
            {
                var cloneObstacle = Instantiate(enemyObstacle, coordinates, Quaternion.identity);
                cloneObstacle.transform.SetParent(gameObject.transform);
                coordinates.x -= enemyObstacle.transform.localScale.x + enemyObstacle.transform.localScale.x / 2;
            }
            coordinates.z -= _enemyObstacle1.transform.localScale.z + _enemyObstacle1.transform.localScale.z / 2;
        }

        coordinates.z -= -2 - (_enemyObstacle1.transform.localScale.z + _enemyObstacle1.transform.localScale.z / 2) * length;
        coordinates.x = 0;
        var wideObstacle = Instantiate(_wideObstacle, coordinates, Quaternion.identity);
        wideObstacle.transform.localScale = new Vector3(x: widthOfTheWideObstacle, y: wideObstacle.transform.localScale.y, z: wideObstacle.transform.localScale.z);
        wideObstacle.transform.SetParent(gameObject.transform);

    }
}