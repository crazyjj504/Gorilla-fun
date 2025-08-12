using UnityEngine;

namespace teatimefox
{
    public class DoorButton : MonoBehaviour
    {
        public Door door;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("HandTag"))
            {
                door.ToggleDoor();
            }
        }
    }
}
