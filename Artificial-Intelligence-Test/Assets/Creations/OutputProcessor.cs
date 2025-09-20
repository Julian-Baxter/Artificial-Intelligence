using Gamekit2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Bindings;

namespace Gamekit2D { 
    public class OutputProcessor : MonoBehaviour, IDataPersister
    {
        public static OutputProcessor Instance
        {
            get { return s_Instance; }
        }

        protected static OutputProcessor s_Instance;
        private PlayerInput playIn;

        // Start is called before the first frame update
        public enum ArtificialButtons
        {
            None,
            Break,
            Activate,
            Strike,
            Shoot,
            Jump,
        }
        public enum ArtificialAxes
        {
            None,
            Up,
            Down,
            Left,
            Right,
        }


        ArtificialButtons artButton;
        ArtificialAxes artAxis;
        public DataSettings dataSettings;

        void Awake()
        {
            Debug.Log("Output Processor Awoken!!");
            if (s_Instance == null)
                s_Instance = this;
            else
                throw new UnityException("There cannot be more than one OutputProcessor script.  The instances are " + s_Instance.name + " and " + name + ".");
        }

        private void OnEnable()
        {
            Debug.Log("Output Processor Enabled!!");
            if (s_Instance == null)
                s_Instance = this;
            else if(s_Instance!=this)
                throw new UnityException("There cannot be more than one OutputProcessor script.  The instances are " + s_Instance.name + " and " + name + ".");
            PersistentDataManager.RegisterPersister(this);

        }

        void Start()
        {
            playIn = gameObject.GetComponent<PlayerInput>();
            artButton = ArtificialButtons.Jump;
            artAxis = ArtificialAxes.None;
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Hello There");
            }

            artButton = ArtificialButtons.Jump;

                if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
            }
            else if(Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow))
            {
            }
            //Debug.Log(playIn.artAxis);
        }
        protected readonly static Dictionary<int, string> a_ButtonsToName = new Dictionary<int, string> {
                {(int)ArtificialButtons.Break, "Break"},
                {(int)ArtificialButtons.Activate, "Activate"},
                {(int)ArtificialButtons.Strike, "Strike"},
                {(int)ArtificialButtons.Shoot, "Shoot"},
                {(int)ArtificialButtons.Jump, "Jump"},
            };

        protected readonly static Dictionary<int, string> a_AxisToName = new Dictionary<int, string> {
                {(int)ArtificialAxes.Up, "Up"},
                {(int)ArtificialAxes.Down, "Down"},
                {(int)ArtificialAxes.Left, "Left"},
                {(int)ArtificialAxes.Right, "Right"},
            };



        public static bool GetKey(string name)
        {
            if (name == a_ButtonsToName[(int)Instance.artButton])
            {
                Debug.Log("Get Key!!!");
                return true;
            }
            return false;
        }
        public static bool GetKeyUp(string name)
        {
            if (name == a_ButtonsToName[(int)Instance.artButton])
            {
                Debug.Log("Get Key Up!!!");
                return true;
            }
            return false;
        }
        public static bool GetKeyDown(string name)
        {
            if (name == a_ButtonsToName[(int)Instance.artButton])
            {
                Debug.Log("Get Key Down!!!");
                return true;
            }
            return false;
        }

        public DataSettings GetDataSettings()
        {
            return dataSettings;
        }

        public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
        {
            dataSettings.dataTag = dataTag;
            dataSettings.persistenceType = persistenceType;
        }
        public Data SaveData()
        {
            throw new NotImplementedException();
        }

        public void LoadData(Data data)
        {
            throw new NotImplementedException();
        }
    }
}
