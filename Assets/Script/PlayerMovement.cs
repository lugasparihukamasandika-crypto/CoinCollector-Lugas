using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // WAJIB untuk TextMeshPro
public class PlayerMovement : MonoBehaviour
{
    public int score = 0;
    public GameManager gameManager;
    public TextMeshProUGUI scoreText;
 public float kecepatan = 5f;
[Header("Input System")]
public InputActionReference inputReference; // referensi ke Input Action Asset
 private Vector2 arahGerak;
  // nilai dari action "Move"
 // Dipanggil OTOMATIS oleh komponen Player Input
 // saat action "Move" pada asset InputSystem_Actions aktif.
 // Nama method WAJIB: On + nama action -> OnMove

 void OnMove(InputValue value)
 {
 // TODO: ambil nilai Vector2 dari input, simpan ke arahGerak
 arahGerak = inputReference.action.ReadValue<Vector2>();
 }
 void Update()
 {
 // TODO: gerakkan objek memakai arahGerak.
 // Ingat kalikan kecepatan DAN Time.deltaTime!
 Vector3 arah = new Vector3(arahGerak.x, arahGerak.y, 0);
 transform.position += arah * kecepatan * Time.deltaTime;
 }
 void OnTriggerEnter2D(Collider2D other)
{
 // TODO: cek apakah yang disentuh punya tag "Coin"
 if (other.CompareTag("Coin"))
 {
 // TODO: hancurkan koin yang tersentuh
 Destroy(other.gameObject);
 score ++;
 scoreText.text = "Score: " + score.ToString();
 gameManager.AmbilKoin(); // panggil method AmbilKoin() di GameManager

 }
}
}