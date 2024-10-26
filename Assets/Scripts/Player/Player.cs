using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] new private Rigidbody2D rigidbody;

    public CarameloManager carameloManager;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        carameloManager = GameObject.Find("GameManager").GetComponent<CarameloManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     if (other.CompareTag("Candy"))  
        {
            Destroy(other.gameObject);
            carameloManager.carameloCount++;
        }
    }

}
