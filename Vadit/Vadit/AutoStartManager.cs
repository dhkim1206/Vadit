using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Xml;
using IWshRuntimeLibrary;

namespace Vadit
{
    public class AutoStartManager
    {
        // 자동 시작 관리자 실행
        public void Run()
        {

            Read_AutoStartStatus();  // 자동 시작 상태 읽기
        }

        // 자동시작 설정
        public void Set_AutoStart()
        {
            // 프로그램 실행 파일의 경로
            //string programPath = Assembly.GetExecutingAssembly().Location;

            string programPath = Path.Combine(Application.StartupPath, "Vadit"); // 사운드 파일 경로를 저장할 변수
            Debug.WriteLine("프로그램 실행 파일의 경로 : " + programPath);
            // 시작 프로그램 폴더 경로 설정
            string startupFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Vadit.lnk");
            Debug.WriteLine("시작 프로그램 폴더 : " + startupFolderPath);
            // 프로그램 실행 파일을 시작 프로그램 폴더에 복사
            System.IO.File.Copy(programPath, startupFolderPath, true);

            /*
            // 바로 가기 파일 생성 및 설정
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "VaditShortcut.lnk");
            Debug.WriteLine("바로가기 파일 경로 " + shortcutPath);
            CreateShortcut(programPath, shortcutPath);
            Debug.WriteLine("프로그램이 윈도우 자동 시작 프로그램으로 등록되었습니다.");*/
        }


        // 자동 시작 해제
        public void Cancel_AutoStart()
        {
            string programPath = Assembly.GetExecutingAssembly().Location;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)  // Windows인 경우
            {
                string startupFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Vadit.lnk");
                if (System.IO.File.Exists(startupFolderPath))
                {
                    System.IO.File.Delete(startupFolderPath);  // 시작 프로그램 폴더에 있는 바로 가기 파일 삭제
                    Debug.WriteLine("프로그램이 윈도우 자동 시작 프로그램에서 제거되었습니다.");
                }
                else Debug.WriteLine("프로그램이 윈도우 자동 시작 프로그램에 등록되어 있지 않습니다.");
            }
            else Debug.WriteLine("지원되지 않는 운영체제입니다.");
        }

        // 자동 시작 상태 읽기
        public void Read_AutoStartStatus()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string configFilePath = "data.xml";  // 설정 파일 경로
                doc.Load(configFilePath);

                XmlNode autoStartNode = doc.SelectSingleNode("//WindowSameExecute");  // 설정 파일에서 자동 시작 노드 찾기
                Debug.WriteLine("WindowSameExecute : " + autoStartNode.InnerText);
                if (autoStartNode != null)
                {
                    if (bool.Parse(autoStartNode.InnerText) == true)
                        Set_AutoStart();  // 자동 시작 설정
                    else if (bool.Parse(autoStartNode.InnerText) == false)
                        Cancel_AutoStart();  // 자동 시작 해제
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading config file: " + ex.Message);
            }
        }

        // 바로 가기 파일 생성
        private void CreateShortcut(string targetPath, string shortcutPath)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            shortcut.Description = "Vadit 프로그램 자동 시작";
            shortcut.Save();
        }
    }
}
