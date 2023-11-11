using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tzar
{
    public class EnumTagsDemo : MonoBehaviour
    {
        [SerializeField] Text debugText;

        private void Start()
        {
            // Enum Tags
            if (CompareTag(Tags.T_Player))
            {
                debugText.text = "This is an object with tag Player";
                // do something
            }
        }
    }
}
