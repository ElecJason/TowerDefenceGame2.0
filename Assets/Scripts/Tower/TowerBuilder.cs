using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private LayerMask _floorLayer;
    [SerializeField] private LayerMask _towerLayer;

    [SerializeField] private float _radius = 1.5f;
    private Vector3 _offset = new Vector3(0,0.5f,0);

    private RaycastHit hit;
    private float _distance = 10;

    private Tower _selectedTower;
    // wellicht zijn er nog meer variabelen nodig dan in het script tot nu toe gedefinieerd zijn.

    void Update()
    {
        // Het eerste gedeelte van de if statement is eigenlijk om deze class makkelijk te kunnen testen
        // uiteindelijk wil je dat de SelectTower functie wordt aangeroepen zodat deze class gaat doen wat ie moet doen.
        if (_selectedTower == null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectTower(_towers[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectTower(_towers[1]);
            }
        }
        else
        {
            UpdateTowerPosition();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DeselectTower();
            }
            else if (ValidateLocation() && Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }
    }
    public void SelectTower(Tower tower)
    {
        // instantieer een toren, maar zorg dat deze nog niet werkt
        // zet de _selectedTower variable
        Debug.Log("Plaats");
        _selectedTower = Instantiate(tower, hit.transform);
        _selectedTower.enabled = false;
        _material = _selectedTower.GetComponent<Renderer>().material;
    }

    private void PlaceTower()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ValidateLocation() == true)
        {
            _material.color = Color.white;
            _selectedTower.enabled = true;
            _selectedTower = null;
        }
        // update de kleur van de toren terug naar de originele kleur
        // zet de toren 'aan'
        // zet de _selectedTower variabel weer terug naar null (letop: niet 0)!
        // overige mogelijkheden:
        // - ParticleEffect afspelen
        // - geluid afspelen
        // - geld verekenen o.i.d.
    }
    private void UpdateTowerPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _floorLayer))
        {
            _selectedTower.transform.position = hit.point + _offset;
        }
        // update de positie van de toren naar de muispositie
    }
    private bool ValidateLocation()
    {   
        Collider[] cols = Physics.OverlapSphere(_selectedTower.transform.position, 1);
        for (int i = 0; i < cols.Length; i++)
        {
            Debug.Log(cols[i]);
        }
        if (cols.Length <= 2)
        {
            _material.color = Color.green;
            return true;
        }
        _material.color = Color.red;
        return false;

            // check of de toren collide met objecten.
            // kan de toren niet geplaatst worden?
            // verander 'm dan van kleur (naar rood bijv)
            // Dit kun je doen door de kleur van het material aan te passen
            // kan die wel geplaatsts worden (maak m dan zijn origene kleur, of groen, of een anere kleur)
    }
    public void DeselectTower()
    {
        Destroy(_selectedTower.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}