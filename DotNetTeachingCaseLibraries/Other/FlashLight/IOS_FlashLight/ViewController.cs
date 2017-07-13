using System;

using UIKit;


using CoreGraphics;

using Foundation;

using AVFoundation;
using CoreMedia;
using CoreVideo;

using CoreFoundation;

namespace IOS_FlashLight
{
    public partial class ViewController : UIViewController
    {

		bool mark = false;
		AVCaptureSession CaptureSession = null;
		AVCaptureDevice videoDevice = null;
        partial void OpenButton_TouchUpInside(UIButton sender)
        {
			if (mark == false)
			{
                //OpenButton.SetTitle("关闭", UIControlState.Normal);
				OpenButton.SetImage(UIImage.FromBundle("Red.png"), UIControlState.Normal);

				#region 摄像头调用
				CaptureSession = new AVCaptureSession();
				CaptureSession.SessionPreset = AVCaptureSession.PresetMedium;
				videoDevice = AVCaptureDevice.GetDefaultDevice(AVMediaType.Video);

				NSError error = null;
				videoDevice.LockForConfiguration(out error);
				if (error != null)
				{
					videoDevice.UnlockForConfiguration();

				}
				videoDevice.TorchMode = AVCaptureTorchMode.On;
				videoDevice.UnlockForConfiguration();

				CaptureSession.StartRunning();
				#endregion

			}
			else
			{
				//OpenButton.SetTitle("打开", UIControlState.Normal);
				OpenButton.SetImage(UIImage.FromBundle("Green.png"), UIControlState.Normal);
				NSError error = null;
				videoDevice.LockForConfiguration(out error);
				if (error != null)
				{
					videoDevice.UnlockForConfiguration();
				}
				videoDevice.TorchMode = AVCaptureTorchMode.Off;
				videoDevice.UnlockForConfiguration();

			}
			mark = !mark;
		
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			OpenButton.SetImage(UIImage.FromBundle("Green.png"), UIControlState.Normal);

			// Perform any additional setup after loading the view, typically from a nib.
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
