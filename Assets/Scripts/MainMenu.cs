using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        public AudioClip hoverFX;
        public AudioClip clickFX;
        public AudioSource audioSource;
        public GameObject PanelOptions;

        bool isOpenned = false;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Options()
        {
            isOpenned = !isOpenned;
            Animator panelAnimator = PanelOptions.GetComponent<Animator>();
            panelAnimator.SetBool("IsOpen", isOpenned);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void ControlSound()
        {
            AudioListener.pause = !AudioListener.pause;
        }

        public void Voltar()
        {
            SceneManager.LoadScene("Menu");
        }

        public void Credits()
        {
            SceneManager.LoadScene("Creditos");
        }


        public void SendEmail()
        {
            string email = "paulo.ti.sousa@gmail.com";
            string subject = MyEscapeURL("Dúvidas, Críticas e Sugestões");
            string body = MyEscapeURL("Olá, eu queria dizer que");
            Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
        }

        public void Rate()
        {
            EditorUtility.DisplayDialog("Title here", "Your text", "Ok");
            Application.OpenURL("market://details?id=" + Application.productName);
        }

        string MyEscapeURL(string url)
        {
            return WWW.EscapeURL(url).Replace("+", "%20");
        }


 

        public void HoverSound()
        {
            myFx.PlayOneShot(hoverFX);
        }
        public void ClickSound()
        {
            myFx.PlayOneShot(clickFX);
        }
    }
}
