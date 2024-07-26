using UnityEngine;

internal class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] BoxingMechanics mechanics;


    // Update is called once per frame
    void Update()
    {
        if (mechanics.OnAttack || mechanics.OnDefense)
            return;

        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        var newPos = speed * Time.deltaTime * new Vector3(move.x, 0.0f, move.y);
        transform.Translate(newPos);

        //For rotation with mouse
        float mouseX = Input.GetAxis("Mouse X");       
        transform.Rotate(0f, mouseX, 0f);
    }
}
