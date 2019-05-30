using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;

namespace FingerPrintValidation
{
    public partial class FingerValidationView : Form, DPFP.Capture.EventHandler
    {
        private Capture Capturer;
        public FingerValidationView()
        {
            InitializeComponent();

            ActiveControl = label1;

            Init(Capturer);
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            throw new NotImplementedException();
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MessageBox.Show("El Lector de huellas fue tocado.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            throw new NotImplementedException();
        }

        #region GRE_Function

        protected virtual void Init(Capture Capturer)
        {
            try
            {
                Capturer = new Capture();

                if (null != Capturer)
                {
                    Capturer.EventHandler = this;

                    SetPrompt("Iniciando operación de captura...");
                }
                else
                {
                    SetPrompt("No se puede iniciar la operación de captura.");
                }
            }
            catch
            {
                SetPrompt("Error al iniciar la operación de captura.");
            }
        }

        private void SetPrompt(string message)
        {
            lbl_Prompt.Text = "";
            lbl_Prompt.Text = message;
        }

        private void DrawingCapture(Bitmap bitmap)
        {
            Invoke(new Function(delegate () {
                img_FingerPrint.Image = new Bitmap(bitmap, img_FingerPrint.Size);
            }));
        }

        delegate void Function();

        #endregion
    }
}
