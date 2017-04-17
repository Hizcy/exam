using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Thumbnail
/// </summary>
public class Thumbnail
{
    /// ��summary> 
    /// ��������ͼ 
    /// ��/summary> 
    /// ��param name="originalImagePath">Դͼ·��������·������/param> 
    /// ��param name="thumbnailPath">����ͼ·��������·������/param> 
    /// ��param name="width">����ͼ��ȡ�/param> 
    /// ��param name="height">����ͼ�߶ȡ�/param> 
    /// ��param name="mode">��������ͼ�ķ�ʽ��/param>   
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://ָ���߿����ţ����ܱ��Σ�            
                break;
            case "W"://ָ�����߰�����                 
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://ָ���ߣ������� 
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://ָ���߿�ü��������Σ�            
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //�½�һ��bmpͼƬ 
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //�½�һ������ 
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //���ø�������ֵ�� 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //���ø�����,���ٶȳ���ƽ���̶� 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //��ջ�������͸������ɫ��� 
        g.Clear(System.Drawing.Color.Transparent);

        //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������ 
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

        try
        {
            //��jpg��ʽ��������ͼ 
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    /**/
    /// ��summary> 
    /// ��ͼƬ����������ˮӡ 
    /// ��/summary> 
    /// ��param name="Path">ԭ������ͼƬ·����/param> 
    /// ��param name="Path_sy">���ɵĴ�����ˮӡ��ͼƬ·����/param> 
    protected void AddWater(string Path, string Path_sy)
    {
        string addText = "www.tzwhx.com";
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font("Verdana", 10);    //����λ��Ϊ���10 
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

        g.DrawString(addText, f, b, 14, 14);    //�����СΪ14X14 
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }

    /**/
    /// ��summary> 
    /// ��ͼƬ������ͼƬˮӡ 
    /// ��/summary> 
    /// ��param name="Path">ԭ������ͼƬ·����/param> 
    /// ��param name="Path_syp">���ɵĴ�ͼƬˮӡ��ͼƬ·����/param> 
    /// ��param name="Path_sypf">ˮӡͼƬ·����/param> 
    protected void AddWaterPic(string Path, string Path_syp, string Path_sypf)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Dispose();

        image.Save(Path_syp);
        image.Dispose();
    }
	
}
