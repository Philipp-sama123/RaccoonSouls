using Animals;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AnimalHelper animal = other.gameObject.GetComponentInParent<AnimalHelper>();

        if (animal != null && animal.animalType == AnimalType.Friend)
        {
            animal.DestroyAnimalPrey(true);
        }
    }
}