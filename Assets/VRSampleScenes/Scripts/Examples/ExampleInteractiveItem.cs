using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.UI;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
        //[SerializeField] private Material m_NormalMaterial;                
        //[SerializeField] private Material m_OverMaterial;                  
        //[SerializeField] private Material m_ClickedMaterial;               
        //[SerializeField] private Material m_DoubleClickedMaterial;
		//[SerializeField] private Text myText;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;

		public GameObject go;
		public Text displayText;
		public Image[] images;

        private void Awake ()
        {
			//m_Renderer.material = m_NormalMaterial;
			displayText.color = Color.white;
			images [0].enabled = false;
			images [1].enabled = false;
			images [2].enabled = false;
        }

		void Update () {
		}

		void displayInfo(float temperature)
		{
			if (temperature < 20) {
				displayText.text = go.name + ":\n " + temperature + "°C\nRoom temperature: low";
				images [0].enabled = true;
				images [1].enabled = false;
				images [2].enabled = false;
			} else if (temperature < 26) {
				displayText.text = go.name + ":\n " + temperature + "°C\nRoom temperature: normal";
				images [0].enabled = false;
				images [1].enabled = true;
				images [2].enabled = false;
			} else {
				displayText.text = go.name + ":\n " + temperature + "°C\nRoom temperature: high";
				images [0].enabled = false;
				images [1].enabled = false;
				images [2].enabled = true;
			}
		}

        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
			displayText.enabled = true;
			ChangeColor cc = go.GetComponent<ChangeColor> ();
			displayInfo (cc.temp);
            //Debug.Log("Show over state");
            //m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
			//displayText.enabled = false;
			images [0].enabled = false;
			images [1].enabled = false;
			images [2].enabled = false;
            //Debug.Log("Show out state");
            //m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
            //Debug.Log("Show click state");
            //m_Renderer.material = m_ClickedMaterial;
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            //Debug.Log("Show double click");
            //m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}