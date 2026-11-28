using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [Header("Aim & Pivot")]
    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPivot;
    [SerializeField] private Transform attackPoint;

    [Header("Combat Settings")]
    [SerializeField] private float attackRange = 0.8f;
    [SerializeField] private int damage = 20;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackCooldown = 0.3f;

    private float _nextAttackTime = 0f;
    private Camera _mainCam;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0) && Time.time >= _nextAttackTime)
        {
            PerformAttack();
            _nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void RotateTowardsMouse()
    {
        if (attackPivot == null || _mainCam == null) return;

        // 1. Lấy vị trí chuột màn hình
        Vector3 mouseScreenPos = Input.mousePosition;

        // 2. Gán khoảng cách Z từ Camera tới mặt phẳng 2D của Player
        // (Đảm bảo tính đúng tọa độ World kể cả khi Cinemachine dùng Perspective)
        mouseScreenPos.z = Mathf.Abs(_mainCam.transform.position.z - transform.position.z);

        // 3. Chuyển sang tọa độ Thế giới
        Vector3 mouseWorldPos = _mainCam.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f; // Đưa về mặt phẳng 2D

        // 4. Tính hướng và xoay Pivot
        Vector2 aimDirection = (mouseWorldPos - attackPivot.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        attackPivot.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void PerformAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            Debug.Log($"Trúng mục tiêu: {hit.name}");
            // hit.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
