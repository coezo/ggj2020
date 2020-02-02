using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    public float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    public float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    private Vector3[] positions = { new Vector3(1, 1, 0), new Vector3(1, -1, 0), new Vector3(-1, -1, 0), new Vector3(-1, 1, 0) };
    private int index = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private void Start()
    {
        StartCoroutine(ShakeScreen());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
        transform.Translate(positions[index] * Time.deltaTime);

        //shakeDuration -= Time.deltaTime * dampingSpeed;
    }

    private IEnumerator ShakeScreen()
    {
        while (true)
        {
            index++;
            if (index == positions.Length)
            {
                index = 0;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
