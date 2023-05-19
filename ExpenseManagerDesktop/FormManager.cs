namespace ExpenseManagerDesktop
{
    public class FormManager : ApplicationContext
    {
        private Form CurrentForm;

        public FormManager()
        {

        }

        public FormManager(Form currentForm)
        {
            CurrentForm = currentForm;
            CurrentForm.FormClosed += (sender, e) => CloseApplication();
            CurrentForm.Show();
        }

        public void OpenNewForm(Form currentForm)
        {
            if(CurrentForm != null)
                CurrentForm.Hide();

            CurrentForm = currentForm;
            CurrentForm.FormClosed += (sender, e) => CloseApplication();
            
            CurrentForm.Show();
        }

        private void CloseApplication()
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
                ForceDispose();
            }
        }

        private void ForceDispose()
        {
            GC.Collect();
        }
    }
}
