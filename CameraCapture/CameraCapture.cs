using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using com.frs.api;

namespace CameraCapture
{
    public partial class CameraCapture : Form
    {
        //declaring global variables
        private Capture capture;        //takes images from camera as image frames
        private bool captureInProgress;
        FRSAPI frs;

        public CameraCapture()
        {
            InitializeComponent();
            
        }
        //------------------------------------------------------------------------------//
        //Process Frame() below is our user defined function in which we will create an EmguCv 
        //type image called ImageFrame. capture a frame from camera and allocate it to our 
        //ImageFrame. then show this image in ourEmguCV imageBox
        //------------------------------------------------------------------------------//
        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> ImageFrame = capture.QueryFrame();
            CamImageBox.Image = ImageFrame;
        }

        //btnStart_Click() function is the one that handles our "Start!" button' click 
        //event. it creates a new capture object if its not created already. e.g at first time
        //starting. once the capture is created, it checks if the capture is still in progress,
        //if so the
        private void btnStart_Click(object sender, EventArgs e)
        {
            #region if capture is not created, create it now
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            if (capture != null)
            {
                if (captureInProgress)
                {  //if camera is getting frames then stop the capture and set button Text
                    // "Start" for resuming capture
                    btnStart.Text = "Start!"; //
                    System.Windows.Forms.Application.Idle -= ProcessFrame;
                }
                else
                {
                   
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Stop" for pausing capture
                    btnStart.Text = "Stop";
                    System.Windows.Forms.Application.Idle += ProcessFrame;
                    
  
                    
                }

                captureInProgress = !captureInProgress;
            }
        }

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }

        private void CameraCapture_Load(object sender, EventArgs e)
        {

        }

        private void CamImageBox_Click(object sender, EventArgs e)
        {

        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageBox1.Image = CamImageBox.Image;
        }
    }
}
