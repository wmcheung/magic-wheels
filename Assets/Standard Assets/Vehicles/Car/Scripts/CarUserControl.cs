using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        private Vector3 touchOrigin = -Vector3.one;

        public bool isDownLeft = false;
        public bool isDownRight = false;
        public bool isDownBrake = false;
        public static float forward = 5f;
        string m_Controls;
        private GameObject[] JoystickUI;
        public GameObject _Camera;

        public float _X;
        public float _Y;
        public float _Z;
        // private Vector3 defaultcameraposition;

        void start() {
            getControls();
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            // defaultcameraposition = Camera.current.transform.position;
        }

        void getControls() {
            //get control style. If none is found, set it to joystick
            m_Controls = PlayerPrefs.GetString("Controls", "Joystick");
            // Debug.Log(m_Controls);
        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            getControls();
            JoystickUI = GameObject.FindGameObjectsWithTag ("Joystick");

            if(m_Controls != "Joystick") {
                foreach(GameObject _Object in JoystickUI) {
                    _Object.SetActive(false);
                }
            }

        }


        private void FixedUpdate()
        {

            float joystickInput = CrossPlatformInputManager.GetAxis("Horizontal");

            float horizontal = Input.GetAxis("Horizontal");
            // float vertical = 5f;
            float vertical = forward;
            float verticalInput = Input.GetAxis("Vertical");
            float leftMove = 0.0f;
            float rightMove = 0.0f;

            #if UNITY_STANDALON || UNITY_WEBPLAYER

            // horizontal = Input.GetAxis ("Horizontal");
            // vertical = (float) (CrossPlatformInputManager.GetAxis ("Vertical"));
            // vertical = 5f;

            // if(horizontal != 0) {
            //     vertical = 0;
            // }

            #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

            #endif

            // if(horizontal != 0 || vertical != 0) {
                // AttemptMove<Wall> (horizontal vertical);
                #if !MOBILE_INPUT
                float handbrake = Input.GetAxis("Jump");
                if(verticalInput != 0) {
                    vertical = verticalInput;
                };

                m_Car.Move(horizontal, vertical, vertical, handbrake);

                #else
                if(verticalInput != 0 || isDownBrake) { //if the brake button is pressed
                    // m_Car.Move(horizontal, verticalInput, verticalInput, 0f);
                    vertical = -5f;
                }

                m_Car.Move(horizontal, vertical, vertical, 0f);

                // Debug.Log(horizontal);

                // if(horizontal <= -0.1f) {
                //     /** MOVING LEFT **/
                //     StartCoroutine(pov_left());
                // }
                //
                // if(horizontal >= 0.1f) {
                //     StartCoroutine(pov_right());
                // }

                float acceleroInput = Input.acceleration.x;

                if(m_Controls == "Joystick") {
                    acceleroInput = 0.0f;
                }

                float direction = 0.0f;

                if(acceleroInput <= -0.05f) {
                    if(acceleroInput <= -1f) {
                        direction = -1f;

                    } else if(acceleroInput <= -0.90f) {
                        direction = -0.90f;

                    } else if(acceleroInput <= -0.80f) {
                        direction = -0.80f;

                    } else if(acceleroInput <= -0.70f) {
                        direction = -0.70f;

                    } else if(acceleroInput <= -0.60f) {
                        direction = -0.60f;

                    } else if(acceleroInput <= -0.50f) {
                        direction = -0.50f;

                    } else if(acceleroInput <= -0.40f) {
                        direction = -0.40f;

                    } else if(acceleroInput <= -0.30f) {
                        direction = -0.30f;

                    } else if(acceleroInput <= -0.20f) {
                        direction = -0.20f;

                    } else if(acceleroInput <= -0.10f) {
                        direction = -0.10f;
                    }

                    m_Car.Move(direction, vertical, vertical, 0f);
                }

                if(acceleroInput >= 0.05f) {
                    if(acceleroInput >= 1f) {
                        direction = 1f;

                    } else if(acceleroInput >= 0.90f) {
                        direction = 0.90f;

                    } else if(acceleroInput >= 0.80f) {
                        direction = 0.80f;

                    } else if(acceleroInput >= 0.70f) {
                        direction = 0.70f;

                    } else if(acceleroInput >= 0.60f) {
                        direction = 0.60f;

                    } else if(acceleroInput >= 0.50f) {
                        direction = 0.50f;

                    } else if(acceleroInput >= 0.40f) {
                        direction = 0.40f;

                    } else if(acceleroInput >= 0.30f) {
                        direction = 0.30f;

                    } else if(acceleroInput >= 0.20f) {
                        direction = 0.20f;

                    } else if(acceleroInput >= 0.10f) {
                        direction = 0.10f;
                    }

                    m_Car.Move(direction, vertical, vertical, 0f);
                }


                // if(acceleroInput <= low && acceleroInput >= -low) {
                //
                //     m_Car.Move(horizontal, vertical, vertical, 0f);
                //
                // } else if (acceleroInput >= low) {
                //         m_Car.Move(0.5f, vertical, vertical, 0f);
                //
                //     if (acceleroInput >= high) {
                //         m_Car.Move(5f, vertical, vertical, 0f);
                //
                //     }
                //
                // } else if (acceleroInput <= -low) {
                //         m_Car.Move(-0.5f, vertical, vertical, 0f);
                //
                //     if(acceleroInput <= -high) {
                //         m_Car.Move(-5f, vertical, vertical, 0f);
                //     }
                //
                // }

                #endif
            // }

            // Debug.Log(joystickInput);

            if(joystickInput <= -0.05f) {
                if(verticalInput != 0 || isDownBrake) {
                    vertical = -5f;
                    // if (joystickInput == -1) {
                    //     m_Car.Move(-2.5f, verticalInput, verticalInput, 0f);
                    // } else {
                    //     m_Car.Move(-5f, verticalInput, verticalInput, 0f);
                    // }
                // } else {
                }

                if(joystickInput <= -1f) {
                    leftMove = -1f;

                } else if(joystickInput <= -0.90f) {
                    leftMove = -0.90f;

                } else if(joystickInput <= -0.80f) {
                    leftMove = -0.80f;

                } else if(joystickInput <= -0.70f){
                    leftMove = -0.70f;

                } else if(joystickInput <= -0.60f) {
                    leftMove = -0.60f;

                } else if(joystickInput <= -0.50f){
                    leftMove = -0.50f;

                } else if(joystickInput <= -0.40f) {
                    leftMove = -0.40f;

                } else if(joystickInput <= -0.30f){
                    leftMove = -0.30f;

                } else if(joystickInput <= -0.20f) {
                    leftMove = -0.20f;

                } else if(joystickInput <= -0.10f){
                    leftMove = -0.10f;

                }

                m_Car.Move(leftMove, vertical, vertical, 0f);
                // }
            }

            if (joystickInput >= 0.05f) {
                if(verticalInput != 0 || isDownBrake) {
                    vertical = -5f;
                }

                if(joystickInput >= 1f) {
                    rightMove = 1f;

                } else if(joystickInput >= 0.90f) {
                    rightMove = 0.90f;

                } else if(joystickInput >= 0.80f) {
                    rightMove = 0.80f;

                } else if(joystickInput >= 0.70f) {
                    rightMove = 0.70f;

                } else if(joystickInput >= 0.60f) {
                    rightMove = 0.60f;

                } else if(joystickInput >= 0.50f) {
                    rightMove = 0.50f;

                } else if(joystickInput >= 0.40f) {
                    rightMove = 0.40f;

                } else if(joystickInput >= 0.30f) {
                    rightMove = 0.30f;

                } else if(joystickInput >= 0.20f) {
                    rightMove = 0.20f;

                } else if(joystickInput >= 0.10f) {
                    rightMove = 0.10f;

                }


                m_Car.Move(rightMove, vertical, vertical, 0f);


                // if(verticalInput != 0) {
                //     if(joystickInput == 1) {
                //         m_Car.Move(5f, verticalInput, verticalInput, 0f);
                //     } else {
                //         m_Car.Move(2.5f, verticalInput, verticalInput, 0f);
                //     }
                // } else {
                //     if(joystickInput == 1) {
                //         m_Car.Move(5f, verticalInput, verticalInput, 0f);
                //     } else {
                //         m_Car.Move(2.5f, vertical, vertical, 0f);
                //     }
                // }
            }
            //
            // if(isDownBrake) {
            //     m_Car.Move(horizontal, -5f, -5f, 0f);
            //
            //     if(isDownLeft || joystickInput <= -0.5) {
            //         if(joystickInput == -1) {
            //             m_Car.Move(-5f, -5f, -5f, 0f);
            //         } else {
            //             m_Car.Move(-2.5f, -5f, -5f, 0f);
            //         }
            //     }
            //
            //     if(isDownRight || joystickInput >= 0.5) {
            //         if(joystickInput == 1) {
            //             m_Car.Move(5f, -5f, -5f, 0f);
            //         } else {
            //             m_Car.Move(2.5f, -5f, -5f, 0f);
            //         }
            //     }
            // }
            //
            // if(isDownLeft && isDownRight) {
            //     m_Car.Move(horizontal, vertical, vertical, 0f);
            //
            //     if(isDownBrake) {
            //         m_Car.Move(horizontal, -5f, -5f, 0f);
            //     }
            // }
        }

        public void OnPointerDownBrake() {
            isDownBrake = true;
        }

        public void OnPointerUpBrake() {
            isDownBrake = false;
        }
    }
}
