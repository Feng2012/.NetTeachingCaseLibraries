using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Hardware.Camera2;

namespace Android_FlashLight
{
	[Activity(Label = "爱心手电", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		Camera camera = null;
		protected SurfaceView _SurfaceView = null;
		string mark = Camera.Parameters.FlashModeOff;

        public CameraDevice mCameraDevice;

        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);		
			SetContentView(Resource.Layout.Main);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView);
			imageView.SetImageResource(Resource.Drawable.Green);
			_SurfaceView = FindViewById<SurfaceView>(Resource.Id.surfaceView);//得到视频预览控件
			imageView.Click += delegate
			{
				try
				{
                    //实例化镜头
                    if (camera == null)
					{
						camera = Camera.Open();
                      
					}
					//判断当前状态是否为关
					if (mark == Camera.Parameters.FlashModeOff)
					{
						camera.StartPreview();//开始摄像头预览
						var parameter = camera.GetParameters();//得到摄像头参数
						parameter.FlashMode = Camera.Parameters.FlashModeTorch;//设置闪光灯开启
						camera.SetParameters(parameter);//复位参数
						camera.SetPreviewDisplay(_SurfaceView.Holder);//设置摄像采集数据显示控件 
						mark = Camera.Parameters.FlashModeTorch;//标识
						imageView.SetImageResource(Resource.Drawable.Red);
					}
					else
					{
						var parameter = camera.GetParameters();//得到摄像头参数
						parameter.FlashMode = Camera.Parameters.FlashModeOff;//设置闪光灯关闭
						camera.SetParameters(parameter);//复位参数                   
						camera.StopPreview();//停止摄像头预览            
						mark = Camera.Parameters.FlashModeOff;   //标识        
						imageView.SetImageResource(Resource.Drawable.Green);
					}
				}
				catch
				{ }
			};
		}
	}
}

