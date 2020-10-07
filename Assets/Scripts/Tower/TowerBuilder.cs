using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private LayerMask _floorLayer;

    [SerializeField] private float _radius = 2;

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
         _selectedTower = Instantiate(tower, transform);
    }

    private void PlaceTower()
    {
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
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if (Physics.Raycast(ray, out hit, _distance, _floorLayer))
        {
            _selectedTower.transform.position = hit.point;
            Debug.Log(hit);
        }

        
        // update de positie van de toren naar de muispositie
    
    }
    private bool ValidateLocation()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _radius, ~_floorLayer);

        if (cols.Length < 1)
        {
            return true;
        }
        Debug.Log("Ik raak niks");
        return false;

            // check of de toren collide met objecten.
            // kan de toren niet geplaatst worden?
            // verander 'm dan van kleur (naar rood bijv)
            // Dit kun je doen door de kleur van het material aan te passen
            // kan die wel geplaatsts worden (maak m dan zijn origene kleur, of groen, of een anere kleur)
    }
    public void DeselectTower()
    {
        Destroy(_selectedTower);
    }
}