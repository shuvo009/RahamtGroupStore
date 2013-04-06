using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using RahamtGroupStore.Model;
using RahamtGroupStore.Model.DatabaseModels;
using RahamtGroupStore.Model.Repository;
using RahamtGroupStore.ViewModel.Common;
namespace RahamtGroupStore.ViewModel.Methods
{
    public class MiraculousMethods
    {
        public byte[] SelectImageFromFile()
        {
            using (var imageOpenBox = new OpenFileDialog())
            {
                imageOpenBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                imageOpenBox.Filter = "JPGE (*.jpg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|All (*.*)|*.*";
                imageOpenBox.FilterIndex = 0;
                imageOpenBox.RestoreDirectory = true;
                if (imageOpenBox.ShowDialog().Equals(DialogResult.OK))
                {
                    var bitMapImage = new Bitmap(imageOpenBox.FileName);
                    ImageFormat bmpFormate = bitMapImage.RawFormat;
                    Image imageToConvert = Image.FromFile(imageOpenBox.FileName);
                    using(var  ms = new MemoryStream())
                    {
                        imageToConvert.Save(ms,bmpFormate);
                        return ms.ToArray();
                    }
                }
                return null;
            }
        }

        public CompanyInformation GetCompanyInformation()
        {
            return new DataRepository<CompanyInformation>().GetAll().FirstOrDefault();
        }

        public static string Sha256Encrypt(string phrase)
        {
            var encoder = new UTF8Encoding();
            var sha256Hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256Hasher.ComputeHash(encoder.GetBytes(phrase));
            return ByteArrayToString(hashedDataBytes);
        }

        private static string ByteArrayToString(byte[] inputArray)
        {
            var output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }

    }
}
