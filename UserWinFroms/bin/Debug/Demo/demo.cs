using System;

namespace CSharpCodeHelper
{
		class CSharpCode  
		{
			private byte[,] Image; 
			private uint imageRow;
			private uint imageCol;
			public uint[] left_line;
			public uint[] right_line;
			public uint[] mid_line;
			
			//图像处理
			public void ImageProccess(byte[,] image)
			{
				this.Image = image;
				left_line = new uint[Image.]
				
				Get_Mid();
				Road_Check();
			}
			
			//中线提取
			private void Get_Mid()
			{
				
			}
			
			//赛道类型判断及相关处理
			private void Road_Check()
			{
				
			}
			
			// ...
		}
}