using UnityEngine;
using System.Collections;

//[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour {
    public float m_speed = 1;

    
    public float m_life = 3;

    // prefab
    public Transform m_rocket;

    protected Transform m_transform;

    float m_rocketRate = 0;

    // ����
    public AudioClip m_shootClip;

    // ����Դ
    protected AudioSource m_audio;

    // ��ը��Ч
    public Transform m_explosionFX;

    // Ŀ��λ��
  //  protected Vector3 m_targetPos;

    // ���������ײ��
   // public LayerMask m_inputMask;
	//float movev=0;

	//float moveh=0;

	// Use this for initialization
	void Start () {

        m_transform = this.transform;

        m_audio = this.GetComponent<AudioSource>();

     //   m_targetPos = this.m_transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        
		if (Input.GetKey(KeyCode.UpArrow)) {
			//movev -= m_speed * Time.deltaTime;
			transform.Translate(Vector3.back * Time.deltaTime*m_speed);
		}

		if(Input.GetKey(KeyCode.DownArrow)){
        
           // movev += m_speed * Time.deltaTime;
			transform.Translate(Vector3.forward * Time.deltaTime*m_speed);
        }

		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(Vector3.right * Time.deltaTime*m_speed);
        
           // moveh += m_speed * Time.deltaTime;
        }

        // ���Ҽ�
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            //moveh -= m_speed * Time.deltaTime;
			transform.Translate(Vector3.left * Time.deltaTime*m_speed);
        }

        // �ƶ�
      //  this.m_transform.Translate( new Vector3( moveh, 0, movev ) );

        //MoveTo();


        m_rocketRate -= Time.deltaTime;
        if ( m_rocketRate <= 0 )
        {
            m_rocketRate = 0.1f;

            if ( Input.GetKey( KeyCode.Space ) || Input.GetMouseButton(0) )
            {
                Instantiate( m_rocket, m_transform.position, m_transform.rotation );

                // �����������
                m_audio.PlayOneShot(m_shootClip);
            }
        }
       

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") != 0)
        {
            m_life -= 1;

            if (m_life <= 0) 
            {
                // ��ը��Ч
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);

                Destroy(this.gameObject);
            }
        }
    }

//    void MoveTo()
//    {
//        if (Input.GetMouseButton(0))
//        {
//            // ��������Ļλ��
//            Vector3 ms = Input.mousePosition;
//            // ����Ļλ��תΪ����
//            Ray ray = Camera.main.ScreenPointToRay(ms);
//            // ������¼������ײ��Ϣ
//            RaycastHit hitinfo;
//            // ��������
//            //LayerMask mask =new LayerMask();
//            //mask.value = (int)Mathf.Pow(2.0f, (float)LayerMask.NameToLayer("plane"));
//            bool iscast = Physics.Raycast(ray, out hitinfo, 1000, m_inputMask);
//            if (iscast)
//            {
//                // �������Ŀ��,��¼������ײ��
//                m_targetPos = hitinfo.point;
//            }  
//        }
//
//        // ʹ��Vector3�ṩ��MoveTowards��������ó�Ŀ���ƶ���λ��
//        Vector3 pos = Vector3.MoveTowards(this.m_transform.position, m_targetPos, m_speed * Time.deltaTime);
//        // ���µ�ǰλ��
//        this.m_transform.position = pos;
//    }


}
