using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SelectionComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _selectionProjection = null;

    private void Start()
    {
        Unselect();
    }

    public void Select()
    {
        ChangeColor(Color.red);
        _selectionProjection.SetActive(true);
    }

    public void Focus()
    {
        ChangeColor(Color.blue);
    }

    public void Unfocus()
    {
        ChangeColor(Color.red);
    }

    public void Unselect()
    {
        _selectionProjection.SetActive(false);
    }

    private void ChangeColor(Color color)
    {
        if(_selectionProjection != null)
        {
            var child = _selectionProjection.GetComponentInChildren<DecalProjector>();
            child.material.SetColor("_BaseColor", color);
        }
    }
}
