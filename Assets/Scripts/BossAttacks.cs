using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount;

    public float startAngle = 0f;
    public float endAngle = 0f;
    private Vector2 bulletMoveDirection;
    public float countDownTimer = 3f;
    public float bossPhase = 60f;

    void Update()
    {
        countDownTimer -= Time.deltaTime;
        bossPhase -= Time.deltaTime;

        if (bossPhase >= 50f)
        {
            bulletsAmount = 5;
            startAngle = 245f;
            endAngle = 290f;
        }

        else if (bossPhase >= 40f)
        {
            bulletsAmount = 8;
            startAngle = 0f;
            endAngle = 360f;
        }

        else if (bossPhase >= 30f)
        {
            Phase3();
        }

        if (countDownTimer <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        if (GetComponentInParent<BossFightDetect>().bossEngaged)
        {
            Fire();
        }
    }

    void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<ChimeraBullet>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
        countDownTimer = 3f;
    }

    void Phase3()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<ChimeraBullet>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
        bossPhase = 60f;
    }
}

