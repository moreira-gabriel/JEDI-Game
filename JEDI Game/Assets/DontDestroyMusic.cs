using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
   void Start() 
   {
        DontDestroyOnLoad(gameObject);
   }
}
