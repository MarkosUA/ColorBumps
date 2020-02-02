using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private FloorMoveContr _moveContr;
    [SerializeField]
    private LastPanelController _panelController;

    private Vector2 _moveDirection = Vector2.zero;

    private float _sidewayForce = 10f;
    private float distance = 10f;

    private float _mouseSens = 1f;
    private float _sideMaxSpeep = 0.5f;
    private float _forwardMaxSpeed = 0.2f;

    private float _borderDistance = 7f;

    private void Update()
    {
#if UNITY_IOS || UNITY_ANDROID
        TestPhoneScript();
#elif UNITY_STANDALONE
        CompMuvement();
#endif
    }

    private void TestPhoneScript()
    {
        if (_moveContr.startMovement)
        {
            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.GetTouch(0);
                if (myTouch.phase == TouchPhase.Moved)
                {
                    if (transform.position.x < _borderDistance && transform.position.x > -_borderDistance)
                    {
                        Vector2 newPosition = myTouch.deltaPosition;
                        newPosition.y = -newPosition.y;
                        _moveDirection = newPosition.normalized;
                        transform.position += new Vector3(_moveDirection.x * _sidewayForce * Time.deltaTime, 0f, _moveDirection.y * _sidewayForce * Time.deltaTime);
                    }
                    else
                    {
                        if (transform.position.x > _borderDistance)
                            transform.position = new Vector3(_borderDistance - 0.001f, transform.position.y, transform.position.z);
                        else
                        if (transform.position.x < -_borderDistance)
                            transform.position = new Vector3(-_borderDistance + 0.001f, transform.position.y, transform.position.z);
                    }
                }
            }
        }
    }

    private void CompMuvement()
    {
        if (_moveContr.startMovement)
        {
            if (Input.GetKey(KeyCode.A) && transform.position.x < _borderDistance)
            {
                transform.Translate(Vector3.right * _sidewayForce * Time.fixedDeltaTime);
            }
            else
            {
                if (Input.GetKey(KeyCode.D) && transform.position.x > -_borderDistance)
                {
                    transform.Translate(Vector3.right * -_sidewayForce * Time.fixedDeltaTime);
                }
            }

            if (Input.GetMouseButton(0) && transform.position.x < _borderDistance && transform.position.x > -_borderDistance)
            {
                if (Input.GetAxis("Mouse X") <= _sideMaxSpeep && Input.GetAxis("Mouse X") >= -_sideMaxSpeep)
                    transform.position += new Vector3(-Input.GetAxis("Mouse X") * _mouseSens, 0f, 0f);
                else
                {
                    if (Input.GetAxis("Mouse X") > _sideMaxSpeep)
                        transform.position += new Vector3(-_sideMaxSpeep * _mouseSens, 0f, 0f);
                    if (Input.GetAxis("Mouse X") < -_sideMaxSpeep)
                        transform.position += new Vector3(_sideMaxSpeep * _mouseSens, 0f, 0f);
                }

                if (Input.GetAxis("Mouse Y") <= _forwardMaxSpeed && Input.GetAxis("Mouse Y") >= -_forwardMaxSpeed)
                    transform.position += new Vector3(0f, 0f, -Input.GetAxis("Mouse Y") * _mouseSens);
                else
                {
                    if (Input.GetAxis("Mouse Y") > _forwardMaxSpeed)
                        transform.position += new Vector3(0f, 0f, -_forwardMaxSpeed * _mouseSens);
                    if (Input.GetAxis("Mouse Y") < -_forwardMaxSpeed)
                        transform.position += new Vector3(0f, 0f, _forwardMaxSpeed * _mouseSens);
                }
            }
            else
            {
                if (transform.position.x > _borderDistance)
                    transform.position = new Vector3(_borderDistance - 0.001f, transform.position.y, transform.position.z);
                else
                    if (transform.position.x < -_borderDistance)
                    transform.position = new Vector3(-_borderDistance + 0.001f, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            _moveContr.startMovement = false;
            _panelController.ActivateFinishPanel(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            _moveContr.startMovement = false;
            _panelController.ActivateFinishPanel(true);
        }
    }
}
