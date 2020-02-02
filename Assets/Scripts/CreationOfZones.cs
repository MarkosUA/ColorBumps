using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationOfZones : MonoBehaviour
{
    [SerializeField]
    private float _widthOfZone;
    [SerializeField]
    private float _lengthOfZone;
    [SerializeField]
    private float _passLength;
    [SerializeField]
    private GameObject _zonePrefab;
    [SerializeField]
    private GameObject _finishLine;

    private float _widthOfFloor;
    private float _lendthOfFloor;
    private float _startZonePosition;

    private int _scaleFactor = 10;

    private void Awake()
    {
        CreateZones();
    }

    private void DeterminingBordersOfTheFreePlace()
    {
        _widthOfFloor = gameObject.transform.localScale.x;
        _lendthOfFloor = gameObject.transform.localScale.z;

        float startLinePosition = GameObject.FindGameObjectWithTag(tag = "StartLine").transform.localPosition.z;
        _startZonePosition = startLinePosition - _passLength;
    }

    private int DeterminationNumberOfZones()
    {
        int numberOfZones;
        float sizeOfTheFreePlace;

        DeterminingBordersOfTheFreePlace();

        if (_lengthOfZone > 0)
        {
            sizeOfTheFreePlace = _lendthOfFloor - Mathf.Abs(_startZonePosition);
            numberOfZones = Mathf.FloorToInt(sizeOfTheFreePlace / _lengthOfZone);

            for (int i = numberOfZones; i > 0; i--)
            {
                if (sizeOfTheFreePlace <= numberOfZones * _lengthOfZone + (numberOfZones + 1) * _passLength)
                {
                    numberOfZones--;
                }
                else
                    break;
            }
        }
        else
        {
            numberOfZones = 0;
        }
        return numberOfZones;
    }

    private void CreateZones()
    {
        DeterminationNumberOfZones();

        float globalStartZonePosition = GameObject.FindGameObjectWithTag(tag = "StartLine").transform.position.z;

        var x = gameObject.transform.position.x;
        var y = gameObject.transform.position.y + 0.1f;
        var z = globalStartZonePosition - ((_lengthOfZone * _scaleFactor) / 2) - _passLength * _scaleFactor;

        Vector3 pos = new Vector3(x, y, z);

        if (_widthOfZone == 0)
        {
            _zonePrefab.transform.localScale = new Vector3(x: _widthOfFloor, y: gameObject.transform.localScale.y, z: _lengthOfZone);
        }
        else
        {
            _zonePrefab.transform.localScale = new Vector3(x: _widthOfZone, y: gameObject.transform.localScale.y, z: _lengthOfZone);
        }

        for (int i = 0; i < DeterminationNumberOfZones(); i++)
        {
            var cloneZone = Instantiate(_zonePrefab, pos, Quaternion.identity);
            pos.z += (-_passLength - _lengthOfZone) * _scaleFactor;
        }
        pos.z -= -_lengthOfZone * _scaleFactor + _passLength * _scaleFactor;
        _finishLine.transform.localScale = new Vector3(x: _widthOfFloor * _scaleFactor, y: _finishLine.transform.lossyScale.y, z: _finishLine.transform.lossyScale.z); ;
        var finishLine = Instantiate(_finishLine, pos, Quaternion.identity);
        finishLine.transform.SetParent(GameObject.Find("Floor").transform);
    }
}
