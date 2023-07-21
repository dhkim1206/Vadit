using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vadit
{
    public class AppBase
    {

        // 그룹 박스로 라디오 버튼 컨트롤
        public static string GetRadioBox(GroupBox gb){
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
        }
    }
}
