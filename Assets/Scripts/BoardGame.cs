using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardGame : MonoBehaviour, IInterectable
{
    private Material _materialInstance;
    private Color _originalColor;

    [SerializeField] private List<BoardGame> _locateToGo = new List<BoardGame>();
    [SerializeField] private List<BoardGame> _lastLocation = new List<BoardGame>();

    [SerializeField] private GameObject _objectInThisPlace;
    [SerializeField] private Transform _SpawObject;

    [SerializeField] private bool _haveObject;
    [SerializeField] private bool _go;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            _materialInstance = renderer.material;
            _originalColor = _materialInstance.GetColor("_BaseColor");
        }
    }

    public void Interect()
    {
        CameraPlayer cameraPlayer = FindAnyObjectByType<CameraPlayer>();

        if (_go)
        {
            _go = false;
            foreach (BoardGame place in _lastLocation)
            {
                place.ResetColor();
                place.LastLocation(new List<BoardGame>());
                place.ClearObject();
            }
            _haveObject = true;

            LastLocation(new List<BoardGame>());
            cameraPlayer.StopInterect();
            return;
        }

        if (_haveObject)
        {
            ResetColor();
            foreach (BoardGame place in _locateToGo)
            {
                place.ActivateGo();
                place.PossibleToInterect();
                place.LastLocation(_locateToGo);
                place.CreatObject(_objectInThisPlace);
            }
            _objectInThisPlace = null;
            _haveObject = false;
            return;
        }

        if (_haveObject == false)
        {
            cameraPlayer.StopInterect();
        }

    }

    public void PossibleToInterect()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Color baseColor = renderer.material.GetColor("_BaseColor");
            Color bluish = new Color(baseColor.r * 0.8f, baseColor.g * 0.8f, 1f, baseColor.a);
            renderer.material.SetColor("_BaseColor", bluish);
        }
    }

    public void ResetColor()
    {
        if (_materialInstance != null)
        {
            _materialInstance.SetColor("_BaseColor", _originalColor);
        }
    }

    public void ActivateGo()
    {
        _go = true;
    }

    public void LastLocation(List<BoardGame> _lastLocationGo) 
    {
        _lastLocation = _lastLocationGo;
    }

    public void CreatObject(GameObject prefabObject)
    {
        _objectInThisPlace = prefabObject;
        _objectInThisPlace.transform.position = _SpawObject.transform.position;
        _haveObject = true;
    }

    public void ClearObject()
    {
        _objectInThisPlace = null;
        _haveObject = false;
    }

}
