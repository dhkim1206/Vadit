using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Vadit.AppBase;

namespace Vadit
{
    public class AppBase
    {
        static public AppConfig AppConf = null;

        // 그룹 박스로 라디오 버튼 컨트롤
        public static string GetRadioBox(GroupBox gb)
        {
            RadioButton radio_Button = gb.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
            if (radio_Button != null)
                return radio_Button.Tag.ToString();
            else
                return null;
        }
        // 문자 입력만 가능
        public static void AllowOnlyLetterInput(object sender)
        {

            //검사
            if (sender is not TextBox) return;

            //형변환
            TextBox textbox = (TextBox)sender;


            textbox.KeyPress += input2_KeyPress;

        }

        // 숫자만 입력
        public static void AllowOnlyNumberInput(object sender)
        {

            //검사
            if (sender is not TextBox) return;

            //형변환
            TextBox textbox = (TextBox)sender;


            textbox.KeyPress += input1_KeyPress;

        }

        // 입력 값이 비어있는지 검사
        public static bool IsEmptyInput(object sender)
        {
            //검사
            if (sender is TextBox)
            {
                //형변환
                TextBox textbox = (TextBox)sender;

                //텍스트가 비어 있다면
                if (textbox.Text == string.Empty)
                {
                    textbox.Focus(); // 포커스 맞춰주기
                    return true;
                }

                else return false;
            }

            //검사
            else if (sender is ComboBox)
            {
                //형변환
                ComboBox comboBox = (ComboBox)sender;

                //텍스트가 비어 있다면
                if (comboBox.Text == string.Empty)
                {
                    comboBox.Focus(); // 포커스 맞춰주기
                    return true;
                }

                else return false;
            }
            else return false;
        }


        // 입력 값이 제대로 잘 들어왓는지 검사
        public static bool ValidateInput(int start, int end)
        {
            //검사
            if (start < end) return true;
            else return false;

        }
        public static void input2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 허용되는 키 입력: 문자, 백스페이스
            if (!Char.IsLetter(e.KeyChar) && (e.KeyChar != '\b')) e.Handled = true;

        }
        public static void input1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 허용되는 키 입력: 0 ~ 9 백스페이스
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != '\b')) e.Handled = true;
        }

        //--------- Form Manager Class ------------//
        public class FormManager
        {
            Form _curForm = null;
            Panel _parentPanel = null;

            public FormManager(Panel parentPanel)
            {
                _parentPanel = parentPanel;
            }

            //클래스 타입을 받아와서 이 안에서 객체를 만들어야함
            //부모도 자식을 접근하지만, 자식도 부모를 접근 할 수 있다.
            public void ChangeForm(Type formType)
            {
                if (_curForm != null)
                {
                    _curForm.Close();
                    _curForm = null;
                }

                _curForm = (Form)Activator.CreateInstance(formType); // 객체 생성
                _curForm.TopLevel = false;
                _curForm.FormBorderStyle = FormBorderStyle.None;
                _curForm.Parent = _parentPanel;
                _curForm.Dock = DockStyle.Fill; // 가득 찬 화면
                _curForm.Show();
            }
            public void CloseCurrentForm()
            {
                if (_curForm != null) _curForm.Close();
            }
        }
        //---------------------------------------------------------------------------
        public class AppConfig
        //---------------------------------------------------------------------------
        {
            // 폼 로드시 파일이 Xml 파일여부 확인 후 없을시 초기값 설정

            public AppConfigClass ConfigSet;
            private XmlSerializer _xmlSeializer;

            public AppConfig(string fileName)
            {

                ConfigSet = new AppConfigClass();

                _xmlSeializer = new XmlSerializer(typeof(AppConfigClass));

                FileInfo fi = new FileInfo("data.xml");

                if (fi.Exists) // Xml파일이있을시 불러오기
                {
                    using (StreamReader reader = new StreamReader("data.xml")) // 불러 오기
                    {
                        ConfigSet = (AppConfigClass)_xmlSeializer.Deserialize(reader); // 형식 지정
                    }
                }


            }
            public bool Save() // 입력된 값을 Xml에 저장
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("data.xml"))
                    {
                        _xmlSeializer.Serialize(writer, ConfigSet);
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public void AutoStart()
            {
                // 프로그램 실행 파일의 경로
                string programPath = Application.StartupPath; // 예: MyApp.exe (윈도우), MyApp (맥 OS, 리눅스, 유닉스)
                string startupFolderPath = "";

                // 운영체제 확인
                if (Environment.OSVersion.Platform == PlatformID.Win32NT) // 윈도우인 경우
                {
                    startupFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "YourProgram"); // 예: C:\Users\Username\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\MyApp.lnk
                }
                else if (Environment.OSVersion.Platform == PlatformID.Unix) // 리눅스 또는 유닉스인 경우
                {
                    startupFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YourProgram"); // 예: ~/.config/autostart/MyApp.desktop
                }
                else if (Environment.OSVersion.Platform == PlatformID.MacOSX) // 맥 OS인 경우
                {
                    string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // 사용자의 홈 디렉토리 경로를 가져옵니다.
                    startupFolderPath = Path.Combine(homeDirectory, "Library", "LaunchAgents", "YourProgram.plist"); // 예: ~/Library/LaunchAgents/MyApp.plist
                }
                else
                {
                    Console.WriteLine("지원되지 않는 운영체제입니다.");
                    return;
                }

                // 프로그램을 자동 시작 폴더로 복사
                if (File.Exists(programPath))
                {
                    string startupPath = Path.Combine(startupFolderPath, Path.GetFileName(programPath));

                    // 프로그램을 자동 시작 폴더로 복사
                    File.Copy(programPath, startupPath, true);

                    Console.WriteLine("프로그램이 자동 시작 프로그램으로 등록되었습니다.");
                }
                else
                {
                    Console.WriteLine("프로그램 파일을 찾을 수 없습니다.");
                }

                Console.ReadLine();
            }
        }
    }

}
